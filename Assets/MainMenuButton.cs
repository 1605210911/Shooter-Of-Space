using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField]
    public Button MenuButton;
    void Start()
    {
        MenuButton.gameObject.SetActive(false);
    }
  public  void LoadMenu(){
        SceneManager.LoadScene(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
