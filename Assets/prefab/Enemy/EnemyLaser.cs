using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private float speed =8f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime* speed);
        if(transform.position.y<-7){
//Check if this object has a parent
// Destroy the parent too
if(transform.parent!= null){
  Destroy(transform.parent.gameObject);
}

          Destroy(this.gameObject);
         
        }
    }
}
