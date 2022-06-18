using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.Icypeak.Orbit
{
    public class Projectile : MonoBehaviour
    {
     void OnTriggerEnter2D(Collider2D col){
        if( col.gameObject.CompareTag("Enemy")){
                Destroy(this.gameObject);
            }
     }
    }
}
