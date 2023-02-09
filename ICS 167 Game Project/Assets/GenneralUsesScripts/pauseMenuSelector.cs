using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kevin Rogan

public class pauseMenuSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameIsPause = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPause){
                resume();
            }
            else{
                pause();
            }
        }
    }
    public void resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPause=false;
    }

    private void pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPause=true;
    }

    public void goToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quitGame(){
        Application.Quit();
    }
}
