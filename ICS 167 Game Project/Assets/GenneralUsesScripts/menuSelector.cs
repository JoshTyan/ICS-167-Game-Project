using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kevin Rogan

public class menuSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScenes(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void changeScenesMultiPlayer(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void quitGame(){
        Application.Quit();
    }
}
