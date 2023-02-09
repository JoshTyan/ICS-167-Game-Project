using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameSystem : MonoBehaviour
{
    
    [SerializeField]
    public GameObject[] player1;
    [SerializeField]
    public GameObject[] player2;
    private int myUnit;
    private int enemyUnit;
    [SerializeField]
    TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        myUnit=player1.Length;
        enemyUnit=player2.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
        int tempIndex=0;
        for(int i = 0; i<player1.Length; i++){
            if(!(player1[i]==null)){
                tempIndex++;
            }
        }
        
        int tempIndex2=0;
        for(int i = 0; i<player2.Length; i++){
            if(!(player2[i]==null)){
                tempIndex2++;
            }
        }
        myUnit = tempIndex;
        enemyUnit = tempIndex2;
        uiText.text = UI_Display();

    }

    public string UI_Display(){
        string retString="";
        retString += "Player 1 Unit Count = " + myUnit + " \n Player 2 Unit Count = " + enemyUnit;
        return retString;
    }
}
