using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // [SerializeField] private float _tripleShotBoosterSpeed= 1f;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*2f);
         if(transform.position.y<-5){
            float randomX = Random.Range(-8f,8f);
            transform.position = new Vector3(randomX,7,0);
        }
        
        
    }


    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag =="Player"){
                Destroy(this.gameObject);
        }
    }
}
