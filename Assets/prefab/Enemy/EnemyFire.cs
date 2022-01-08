using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
        float _canfire;
        [SerializeField] float _fireRate =3f;
        [SerializeField] GameObject _EnemyLaserPrefab;
        [SerializeField]
         bool EnemyLive = true;
        
    // Start is called before the first frame update
    void Start()
    {
        // enemy = FindObjectOfType(typeof(Enemy)) as Enemy; 
        
    }
    
    // Update is called once per frame
    void Update()
    {
         if(Time.time>_canfire&&EnemyLive==true){
             fireLaser();
        }
        
    }
   public void enemyLive(){
        EnemyLive= false; 
        

    }
        void fireLaser(){
        if(EnemyLive==true){
        _canfire =Time.time +_fireRate;

    
             
           Instantiate(_EnemyLaserPrefab,transform.position+ new Vector3(0,-0.8f,0),Quaternion.identity);
        
        
        }    
           
    }
}
