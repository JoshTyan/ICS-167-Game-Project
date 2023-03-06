using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

//Kevin Rogan

public class gameSystem : MonoBehaviour
{
    
    [SerializeField]
    public GameObject[] player1;
    [SerializeField]
    public GameObject[] player2;
    private int myUnit;
    private int enemyUnit;
    private int turnCount = 1;

    [SerializeField]
    TextMeshProUGUI uiUnitTracker;
    [SerializeField]
    TextMeshProUGUI uiTurnCounter;
    [SerializeField]
    TextMeshProUGUI uiUnitName;
    [SerializeField]
    TextMeshProUGUI uiTurnChange;

    // Start is called before the first frame update
    void Start()
    {
        myUnit=player1.Length;
        enemyUnit=player2.Length;
    }

    // Update is called once per frame
    void Update()
    {
        updateTurnChange();
        //player1Move();

        updateTurnCounter();
        
        player1Move();

        updateTurnChange();

        player2Move();


        updateUnitNum();
        
        turnCount++;
        

    }

    private void player1Move(){
        if(player1[0] != null){
            updateUnitName("Fire Knight");
            player1[0].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause1());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player1[0].GetComponent<CharacterScript>().enabled = false;
        }   
        if(player1[1] != null){
            updateUnitName("Wind Archer");
            player1[1].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause2());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player1[1].GetComponent<CharacterScript>().enabled = false;
        }
        if(player1[2] != null){
            updateUnitName("Water Mage");
            player1[2].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause3());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player1[2].GetComponent<CharacterScript>().enabled = false;
        }
        if(player1[3] != null){
            updateUnitName("Holy Priest");
            player1[3].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause4());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player1[3].GetComponent<CharacterScript>().enabled = false;
        }
        if(player1[4] != null){
            updateUnitName("Void Witch");
            player1[4].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause5());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player1[4].GetComponent<CharacterScript>().enabled = false;
        }
    }


    private void updateTurnChange(){

    }

    private void player2Move(){
        if(player2[0] != null){
            updateUnitName("Fire Knight");
            player2[0].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause1());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player2[0].GetComponent<CharacterScript>().enabled = false;
        }   
        if(player2[1] != null){
            updateUnitName("Wind Archer");
            player2[1].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause2());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player2[1].GetComponent<CharacterScript>().enabled = false;
        }
        if(player2[2] != null){
            updateUnitName("Water Mage");
            player2[2].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause3());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player2[2].GetComponent<CharacterScript>().enabled = false;
        }
        if(player2[3] != null){
            updateUnitName("Holy Priest");
            player2[3].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause4());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player2[3].GetComponent<CharacterScript>().enabled = false;
        }
        if(player2[4] != null){
            updateUnitName("Void Witch");
            player2[4].GetComponent<CharacterScript>().enabled = true;
            //StartCoroutine(pause5());
            int finit = 0;
            while(true){
                if(Input.GetMouseButtonDown(0)||finit == 100000) break;
                finit++;
            }
            player2[4].GetComponent<CharacterScript>().enabled = false;
        }
    }

    private void updateTurnCounter(){
        uiTurnCounter.text=turnCount.ToString();
    }

    private void updateUnitName(string nameStr){
        uiUnitName.text=nameStr;
    }
/*
    IEnumerator pause1(){
        yield return new WaitForSeconds(100);
        player1[0].GetComponent<CharacterScript>().enabled = false;
        Debug.Log("DONE");
    }

    IEnumerator pause2(){
        
        yield return new WaitForSeconds(100);
        player1[1].GetComponent<CharacterScript>().enabled = false;
    }

    IEnumerator pause3(){
        
        yield return new WaitForSeconds(100);
        player1[2].GetComponent<CharacterScript>().enabled = false;
    }

    IEnumerator pause4(){
        
        yield return new WaitForSeconds(100);
        player1[3].GetComponent<CharacterScript>().enabled = false;
    }

    IEnumerator pause5(){
        
        yield return new WaitForSeconds(100);
        player1[4].GetComponent<CharacterScript>().enabled = false;
    }
*/
    public void updateUnitNum(){
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
        uiUnitTracker.text = UI_Display();
    }

    public string UI_Display(){
        string retString="";
        retString += "Player 1 Unit Count = " + myUnit + " \n Player 2 Unit Count = " + enemyUnit;
        return retString;
    }
}
