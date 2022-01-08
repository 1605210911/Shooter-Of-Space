using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpSpawn : MonoBehaviour
{
    [SerializeField] GameObject SpeedPrefab;
    [SerializeField] GameObject SpeedContainer;
    public bool stopSpawnSpeed = false;
    void Start()
    {
       StartCoroutine(powerUpfun());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator powerUpfun(){
        while(stopSpawnSpeed== false){
         Vector3 posToSpawn = new Vector3(Random.Range(-7f,7f),6f,0);
        GameObject newSpeedUp = Instantiate(SpeedPrefab,posToSpawn,Quaternion.identity);
        newSpeedUp.transform.parent = SpeedContainer.transform;
        yield return new WaitForSeconds(Random.Range(20f,50f));
        }
     
    }
    public void stopSpeedUp(){
        stopSpawnSpeed = true;
    }


}
