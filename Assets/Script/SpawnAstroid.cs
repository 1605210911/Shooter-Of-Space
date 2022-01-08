using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAstroid : MonoBehaviour
{
    [SerializeField] GameObject astroidPrefab;
    [SerializeField] GameObject astroidContainer;

    bool astroidspawnbool= true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Astroidfun());
        
    }

    // Update is called once per frame
    void Update()
    {
    }
        IEnumerator Astroidfun(){
        while(astroidspawnbool == true){
            Vector3 posToSpawn = new Vector3(Random.Range(-8f,8f),7f,0);
   GameObject newAstroidSpawn = Instantiate(astroidPrefab,posToSpawn,Quaternion.identity);
   newAstroidSpawn.transform.parent = astroidContainer.transform;
   yield return new WaitForSeconds(5f);
        }
        
    }
    public void StopAstroidSpawn(){
        astroidspawnbool = false;
    }
}
