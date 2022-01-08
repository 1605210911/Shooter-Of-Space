using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*2f);
        if(transform.position.y<-10f){
            transform.position = new Vector3(Random.Range(-7f,7f),5f,0);
        }
    }
     void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}
