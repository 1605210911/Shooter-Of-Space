using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartPage : MonoBehaviour
{
     void Start() {
    // StartCoroutine(LoadMenu());
        
    }
public void LoadGame(){
        SceneManager.LoadScene(1);

}
// IEnumerator LoadMenu(){
//     yield return new WaitForSeconds(5f);
//     SceneManager.LoadScene(0);

// }
}
