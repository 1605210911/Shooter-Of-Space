using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _FinalEnemyprefab;
    FinalEnemy finalEnemy;

    
    void Start()
    {
        _FinalEnemyprefab.SetActive(false);
        finalEnemy = FindObjectOfType(typeof(FinalEnemy)) as FinalEnemy;


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void finalEnemyStart()
    {
        
            _FinalEnemyprefab.SetActive(true);

     



    }
}
