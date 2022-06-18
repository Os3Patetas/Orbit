using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Icypeak.Orbit

{
    public class Gunner : MonoBehaviour 
   { 
    
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Update()
        {if(Input.GetKeyDown(KeyCode.Z))
            {
            var bullet = Instantiate(bulletPrefab, this.transform.position,Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f) * bulletSpeed;
        }
        }
        }

}
