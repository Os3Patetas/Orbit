using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

namespace com.Icypeak.Orbit.Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        PlayerInput _input;

        public Vector3 pressPos;
        public bool IsPressing;
        public bool IsDragging;
        public float mouseDragPhysicsSpeed = 10;
        WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

        void Awake()
        {
            _input = new PlayerInput();
        }

        void Update()
        {
            if (IsDragging)
                pressPos = _input.Movement.PressPos.ReadValue<Vector2>();
        }

        void OnEnable()
        {
            _input.Enable();
            _input.Movement.Press.started += PressStarted;
            _input.Movement.Press.canceled += PressCanceled;
        }

        void OnDisable()
        {
            _input.Disable();
            _input.Movement.Press.started -= PressStarted;
            _input.Movement.Press.canceled -= PressCanceled;
        }

        void PressStarted(InputAction.CallbackContext ctx)
        {
            IsPressing = true;
            pressPos = _input.Movement.PressPos.ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(pressPos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
                StartCoroutine(DragUpdate(hit.collider.gameObject));
        }

        void PressCanceled(InputAction.CallbackContext ctx)
        {
            IsPressing = false;
            pressPos = Vector3.zero;
        }

        IEnumerator DragUpdate(GameObject pressedObj)
        {
            float initialDistance = Vector3.Distance(pressedObj.transform.position, Camera.main.transform.position);
            pressedObj.TryGetComponent<Rigidbody2D>(out var _rb);
            Ray ray;
            Vector3 dir;
            while (IsPressing)
            {
                ray = Camera.main.ScreenPointToRay(pressPos);
                if (_rb != null)
                {
                    IsDragging = true;
                    dir = ray.GetPoint(initialDistance) - pressedObj.transform.position;
                    _rb.velocity = new Vector2(dir.x * mouseDragPhysicsSpeed, _rb.velocity.y);
                    yield return _waitForFixedUpdate;
                }
            }
            IsDragging = false;
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }
    }
}
