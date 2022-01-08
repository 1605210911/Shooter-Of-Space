using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float RotateSpeed = 2f;
    int  astroidPower = 2;
    Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        {
        // transform.Translate(Vector3.down*Time.deltaTime* speed);
        transform.Rotate(Vector3.forward * RotateSpeed* Time.deltaTime);
        
        if(transform.position.y<-5){
            float randomX = Random.Range(-8f,8f);
            transform.position = new Vector3(randomX,7,0);
        }
    }
          void OnTriggerEnter2D(Collider2D other) {
         if(other.tag=="Player"){
             Player player = other.transform.GetComponent<Player>();
             if(player != null){
                  player.Damage();
                  player.shieldDeactivate();
             }
           
            Destroy(this.gameObject);
            speed =0 ;
                   
         }
         
         if(other.tag == "Laser"){
                 Destroy(other.gameObject);

             if(astroidPower==0){
           

                Destroy(this.gameObject);
                speed = 0;
             }
             astroidPower--;
             if(player != null){
             player.updateScore(10);


             }
         }
       }   
}
