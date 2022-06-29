using UnityEngine;

namespace com.Icypeak.Orbit.General
{
    [CreateAssetMenu(menuName="Skin/New", fileName="Skin")]
    [System.Serializable]
    public class Skin : ScriptableObject
    {
        public float RotationSpeed;
        public Sprite InitialSprite;
        public Animator Animator;
    }
}
