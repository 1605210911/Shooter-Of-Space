using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyPrefab1;
    [SerializeField] private GameObject _enemyPrefab2;
    [SerializeField] private GameObject _enemyContainer;
   private bool _stopSpawn =false; 
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnChopper());
        
    }

    void Update()
    {
        
    }
    IEnumerator SpawnChopper(){
while(_stopSpawn==false){
             Vector3 posToSpawn1 = new Vector3(Random.Range(-8f,8f),7f,0);

          GameObject newEnemy1 =  Instantiate(_enemyPrefab1, posToSpawn1,Quaternion.identity);
           newEnemy1.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(4,10));
}
           


    }
    IEnumerator SpawnRoutine(){
        while(_stopSpawn == false){
            Vector3 posToSpawn = new Vector3(Random.Range(-8f,8f),7f,0);
          GameObject newEnemy =  Instantiate(_enemyPrefab, posToSpawn,Quaternion.identity);

           newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(Random.Range(5,12));
        }
    }
    public void OnPlayerDeath(){
        _stopSpawn = true;

    }
}
