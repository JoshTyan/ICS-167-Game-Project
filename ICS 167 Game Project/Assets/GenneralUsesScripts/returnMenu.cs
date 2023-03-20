using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kevin Rogan

public class returnMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeToMenu(){
        SceneManager.LoadScene("Menu");
    }
}
