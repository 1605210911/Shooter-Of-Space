using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlLevels : MonoBehaviour
{
   public GameObject lock1;
    public Button level2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Level1") == 1)
        {
            lock1.SetActive(false);
            level2.interactable = true;
        }
    }
}
