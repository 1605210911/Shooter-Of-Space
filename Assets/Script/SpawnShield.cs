using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] GameObject shieldContainer;
    [SerializeField] bool shieldspawnbool = true;
    void Start()
    {
        StartCoroutine(shieldfun());
    }

    
    void Update()
    {

        
    }
    IEnumerator shieldfun(){
        while(shieldspawnbool == true){
            Vector3 posToSpawn = new Vector3(Random.Range(-8f,8f),7f,0);
   GameObject newShieldSpawn = Instantiate(shieldPrefab,posToSpawn,Quaternion.identity);
   newShieldSpawn.transform.parent = shieldContainer.transform;
   yield return new WaitForSeconds(15f);
        }
        
    }
    public void StopShieldSpawn(){
        shieldspawnbool = false;
    }
  
}
