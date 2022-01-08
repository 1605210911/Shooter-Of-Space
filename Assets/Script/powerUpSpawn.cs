using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawn : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] GameObject _triplePrefab;
      [SerializeField] GameObject _tripleContainer;

      // [SerializeField] float _tripleShotBoosterSpeed = 1f;
      bool _stopPowerSpawn = false;
    void Start()
    {
        StartCoroutine(powerUpSpawnfun());
    }

    // Update is called once per frame
    void Update()
    
    {
       
        
    }
    IEnumerator powerUpSpawnfun(){
        while(_stopPowerSpawn == false){
  Vector3 posToSpawn = new Vector3(Random.Range(-8f,8f),7f,0);
        //  Instantiate(_tripleContainer,posToSpawn,Quaternion.identity);
         GameObject newPowerUp = Instantiate(_triplePrefab,posToSpawn,Quaternion.identity);

          newPowerUp.transform.parent = _tripleContainer.transform;
          float waitSecond = Random.Range(20,40);
        yield return new WaitForSeconds(waitSecond);
        }     
      
   }
   public void stopPowerupSpawn(){
       _stopPowerSpawn = true;
   }
   
}
