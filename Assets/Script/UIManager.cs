using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Handle to text
    [SerializeField]
    private Text _ScoreText;
    [SerializeField] private  Image _LiveImg;
  
    [SerializeField] Sprite[] _liveSprites;
    [SerializeField] private Text GameOverText;
    [SerializeField] private bool LoopBool = true;
    
    public bool reloadLevelbool;
    [SerializeField] Button MenuButton;

    void Start()
    {
    _ScoreText.text = "Score: "+ 0;
    reloadLevelbool = false;
    MenuButton.gameObject.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void updateUI(int score){
        _ScoreText.text = "Score: "+ score;
        
    }
    

    public void UpdateLive(int currentLives){
        _LiveImg.sprite = _liveSprites[currentLives];
        if(currentLives == 0){
           
            StartCoroutine(GameOver());
            StartCoroutine(Menufun());


        }
    }
    IEnumerator GameOver(){
        while(LoopBool == true){
        GameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameOverText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        }
    }


 

    IEnumerator Menufun(){
        yield return new WaitForSeconds(5f);
        MenuButton.gameObject.SetActive(true);
    }
    public  void LoadMenu(){
        SceneManager.LoadScene(0);

    }
   
}
