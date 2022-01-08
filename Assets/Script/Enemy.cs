using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int  enemyPower = 1;
    [SerializeField]    float speed =4;
    Player player;
   new Collider2D collider2D;
   AudioSource EnemyExplosion;
    // Handle to Animator Component
    Animator _Anim;
     EnemyFire enemyFire;
  
    void Start()
    {
        
        player = FindObjectOfType(typeof(Player)) as Player;
        collider2D = GetComponent<Collider2D>();
        EnemyExplosion = GetComponent<AudioSource>();
        enemyFire= FindObjectOfType(typeof(EnemyFire)) as EnemyFire;
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
            if(transform.childCount>0){
                Debug.Log("Child exist");
            }
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
                EnemyExplosion.Play();
                Destroy(transform.GetChild(0).gameObject);
            Destroy(this.gameObject,2.5f);
            collider2D.enabled = false;
            speed =0 ;
                   
         }
         
         if(other.tag == "Laser"){
            Destroy(other.gameObject);
           
                    
            if(enemyPower==0){
                //  StartCoroutine(DoDeleteAll());
               
                _Anim.SetTrigger("OnEnemyDeath");

                EnemyExplosion.Play();
                collider2D.enabled = false;
                
                Destroy(transform.GetChild(0).gameObject);

                Destroy(this.gameObject,2.5f);
                
                speed = 0;
            }

             enemyPower--;
             if(player != null){
             player.updateScore(10);
            }
         }
       }
       
    }