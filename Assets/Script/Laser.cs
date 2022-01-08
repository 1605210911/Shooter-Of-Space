using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed =8f;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime* speed);
        if(transform.position.y>6.5){
//Check if this object has a parent
// Destroy the parent too
if(transform.parent!= null){
  Destroy(transform.parent.gameObject);
}

          Destroy(this.gameObject);
         
        }
    }
}
