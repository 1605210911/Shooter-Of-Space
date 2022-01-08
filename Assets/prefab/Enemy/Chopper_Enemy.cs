using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopper_Enemy : MonoBehaviour
{
     [SerializeField] int  enemyPower =2;
    [SerializeField]    float speed =4;
    Player player;
   new Collider2D collider2D;
//    AudioSource EnemyExplosion;
    // Handle to Animator Component
    Animator _Anim;
     public bool EnemyLive = true;
  
    void Start()
    {
        
        player = FindObjectOfType(typeof(Player)) as Player;
        collider2D = GetComponent<Collider2D>();
        // EnemyExplosion = GetComponent<AudioSource>();
    // null checking player
    if(player!= null){
        if(_Anim = null){
            Debug.LogError("The Animator is null");
        }
        _Anim = GetComponent<Animator>();
    }
    else
    Debug.Log("Player is null");
       
    } 
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime* speed);
        
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
           _Anim.SetTrigger("OnEnemyDeath");
                // EnemyExplosion.Play();
            Destroy(this.gameObject);
            collider2D.enabled = false;
            speed =0 ;
                   
         }
         
         if(other.tag == "Laser"){
                 Destroy(other.gameObject);
                    
             if(enemyPower==0){
                 EnemyLive = false;
        //    _Anim.SetTrigger("OnEnemyDeath");
                
                // EnemyExplosion.Play();
                collider2D.enabled = false;
                Destroy(this.gameObject);
                speed = 0;
             }
             enemyPower--;
             if(player != null){
             player.updateScore(10);
             }
         }
       }
    }