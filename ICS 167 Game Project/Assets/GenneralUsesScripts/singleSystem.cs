using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

//Kevin Rogan

public class singleSystem : MonoBehaviour
{
   [SerializeField]
    public GameObject[] player1;
    [SerializeField]
    public GameObject[] player2;
    private int myUnit;
    private int enemyUnit;
    private int turnCount = 1;
    private bool hasNotFinished1=true;
    private bool hasNotFinished2=true;
    private bool hasNotFinished3=true;
    private bool hasNotFinished4=true;
    private bool hasNotFinished5=true;
    private float counter1=10f;
    private float counter2=10f;
    private float counter3=10f;
    private float counter4=10f;
    private float counter5=10f;

    private bool hasNotFinished1_2=true;
    private bool hasNotFinished2_2=true;
    private bool hasNotFinished3_2=true;
    private bool hasNotFinished4_2=true;
    private bool hasNotFinished5_2=true;
    private float counter1_2=10f;
    private float counter2_2=10f;
    private float counter3_2=10f;
    private float counter4_2=10f;
    private float counter5_2=10f;

    private bool trunPlayer1=true;

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
        
        

        
        if(trunPlayer1==true){
            updateTurnChange();
            updateTurnCounter();
            player1Move();
        }
        else{
            updateTurnChange();
            player2Move();
        }
        

        if(myUnit==0){
            SceneManager.LoadScene("Player2Win");
        }
        if(enemyUnit==0){
            SceneManager.LoadScene("Player1Win");
        }

        


        
        
        
        

    }

    private void player1Move(){
        if(player1[0]==null){
            hasNotFinished1=false;
        }
        if(player1[1]==null){
            hasNotFinished2=false;
        }
        if(player1[2]==null){
            hasNotFinished3=false;
        }
        if(player1[3]==null){
            hasNotFinished4=false;
        }
        if(player1[4]==null){
            hasNotFinished5=false;
        }





        if(player1[0] != null){
            updateUnitName("Fire Knight");
            player1[0].GetComponent<CharacterScript>().enabled = true;
            
            updateUnitNum();
            if(counter1 > 0){
                counter1-=Time.deltaTime;
            }
            else{
                hasNotFinished1=false;
            }
            if(hasNotFinished1==false){
                player1[0].GetComponent<CharacterScript>().enabled = false;
                counter1=10;
            }
        }   
        if(player1[1] != null && hasNotFinished1==false){
            updateUnitName("Wind Archer");
            player1[1].GetComponent<CharacterScript>().enabled = true;
            
            updateUnitNum();
            if(counter2 > 0){
                counter2-=Time.deltaTime;
            }
            else{
                hasNotFinished2=false;
            }
            if(hasNotFinished2==false){
                player1[1].GetComponent<CharacterScript>().enabled = false;
                counter2=10;
            }
        }
        if(player1[2] != null&&hasNotFinished1==false&&hasNotFinished2==false){
            updateUnitName("Water Mage");
            player1[2].GetComponent<CharacterScript>().enabled = true;
            
            updateUnitNum();
            if(counter3 > 0){
                counter3-=Time.deltaTime;
            }
            else{
                hasNotFinished3=false;
            }
            if(hasNotFinished3==false){
                player1[2].GetComponent<CharacterScript>().enabled = false;
                counter3=10;
            }
        }
        if(player1[3] != null&&hasNotFinished1==false&&hasNotFinished2==false&&hasNotFinished3==false){
            updateUnitName("Holy Priest");
            player1[3].GetComponent<CharacterScript>().enabled = true;
            
            updateUnitNum();
            if(counter4 > 0){
                counter4-=Time.deltaTime;
            }
            else{
                hasNotFinished4=false;
            }
            if(hasNotFinished4==false){
                player1[3].GetComponent<CharacterScript>().enabled = false;
                counter4=10;
            }
        }
        if(player1[4] != null&&hasNotFinished1==false&&hasNotFinished2==false&&hasNotFinished3==false&&hasNotFinished4==false){
            updateUnitName("Void Witch");
            player1[4].GetComponent<CharacterScript>().enabled = true;
            
            updateUnitNum();
            if(counter5 > 0){
                counter5-=Time.deltaTime;
            }
            else{
                hasNotFinished5=false;
            }
            if(hasNotFinished5==false){
                player1[4].GetComponent<CharacterScript>().enabled = false;
                counter5=10;
            }
        }
        if(hasNotFinished1==false&&hasNotFinished2==false&&hasNotFinished3==false&&hasNotFinished4==false&&hasNotFinished5==false){
            hasNotFinished1=true;
            hasNotFinished2=true;
            hasNotFinished3=true;
            hasNotFinished4=true;
            hasNotFinished5=true;

            trunPlayer1=false;
        }
    }


    private void updateTurnChange(){
        if(trunPlayer1==true){
            uiTurnChange.text = "Player 1's turn";
        }
        else{
            uiTurnChange.text = "Player 2's turn";
        }
    }

    private void player2Move(){
        if(player2[0]==null){
            hasNotFinished1_2=false;
        }
        if(player2[1]==null){
            hasNotFinished2_2=false;
        }
        if(player2[2]==null){
            hasNotFinished3_2=false;
        }
        if(player2[3]==null){
            hasNotFinished4_2=false;
        }
        if(player2[4]==null){
            hasNotFinished5_2=false;
        }




        if(player2[0] != null){
            updateUnitName("Fire Knight");
            player2[0].GetComponent<SinglePlayerAI>().enabled = true;
            
            updateUnitNum();
            if(counter1_2 > 0){
                counter1_2-=Time.deltaTime;
            }
            else{
                hasNotFinished1_2=false;
            }
            if(hasNotFinished1_2==false){
                player2[0].GetComponent<SinglePlayerAI>().enabled = false;
                counter1_2=10;
            }
        }   
        if(player2[1] != null && hasNotFinished1_2==false){
            updateUnitName("Wind Archer");
            player2[1].GetComponent<SinglePlayerAI>().enabled = true;
            
            updateUnitNum();
            if(counter2_2 > 0){
                counter2_2-=Time.deltaTime;
            }
            else{
                hasNotFinished2_2=false;
            }
            if(hasNotFinished2_2==false){
                player2[1].GetComponent<SinglePlayerAI>().enabled = false;
                counter2_2=10;
            }
        }
        if(player2[2] != null&&hasNotFinished1_2==false&&hasNotFinished2_2==false){
            updateUnitName("Water Mage");
            player2[2].GetComponent<SinglePlayerAI>().enabled = true;
            
            updateUnitNum();
            if(counter3_2 > 0){
                counter3_2-=Time.deltaTime;
            }
            else{
                hasNotFinished3_2=false;
            }
            if(hasNotFinished3_2==false){
                player2[2].GetComponent<SinglePlayerAI>().enabled = false;
                counter3_2=10;
            }
        }
        if(player2[3] != null&&hasNotFinished1_2==false&&hasNotFinished2_2==false&&hasNotFinished3_2==false){
            updateUnitName("Holy Priest");
            player2[3].GetComponent<SinglePlayerAI>().enabled = true;
            
            updateUnitNum();
            if(counter4_2 > 0){
                counter4_2-=Time.deltaTime;
            }
            else{
                hasNotFinished4_2=false;
            }
            if(hasNotFinished4_2==false){
                player2[3].GetComponent<SinglePlayerAI>().enabled = false;
                counter4_2=10;
            }
        }
        if(player2[4] != null&&hasNotFinished1_2==false&&hasNotFinished2_2==false&&hasNotFinished3_2==false&&hasNotFinished4_2==false){
            updateUnitName("Void Witch");
            player2[4].GetComponent<SinglePlayerAI>().enabled = true;
            
            updateUnitNum();
            if(counter5_2 > 0){
                counter5_2-=Time.deltaTime;
            }
            else{
                hasNotFinished5_2=false;
            }
            if(hasNotFinished5_2==false){
                player2[4].GetComponent<SinglePlayerAI>().enabled = false;
                counter5_2=10;
            }
        }
        if(hasNotFinished1_2==false&&hasNotFinished2_2==false&&hasNotFinished3_2==false&&hasNotFinished4_2==false&&hasNotFinished5_2==false){
            hasNotFinished1_2=true;
            hasNotFinished2_2=true;
            hasNotFinished3_2=true;
            hasNotFinished4_2=true;
            hasNotFinished5_2=true;

            trunPlayer1=true;
            turnCount++;
        }
    }

    private void updateTurnCounter(){
        uiTurnCounter.text=turnCount.ToString();
    }

    private void updateUnitName(string nameStr){
        uiUnitName.text=nameStr;
    }

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
