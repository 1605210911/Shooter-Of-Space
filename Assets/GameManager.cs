using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uIManager;
    void Start()
    {
        uIManager = FindObjectOfType(typeof(UIManager)) as UIManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
