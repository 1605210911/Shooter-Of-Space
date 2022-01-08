using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float shieldFallSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*shieldFallSpeed);
    }
     private void OnTriggerEnter2D(Collider2D other) {
         if(other.tag == "Player"){
            Destroy(this.gameObject);
         }
         
    }
}
