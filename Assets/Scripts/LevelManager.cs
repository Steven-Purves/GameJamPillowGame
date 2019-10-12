using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int NumOfRoundToWin = 2;
    int roundNum;
    public Shake shakeCam;
    TheGameManger theGameManger;
    public GameObject ko;

    bool playerOneWins;
    bool playerTwoWins;

    public bool GameOver;

    public Fade fader;

    int playerOneRoundsWon;
    int playerTwoRoundsWon;

    public int playerOneHealth = 5;
    public int playerTwoHealth = 5;

    public Hearts playerOneHearts; 
    public Hearts playerTwoHearts;

  //  public event System.Action OnShake;

    public PlayerMove playerOne;
    public PlayerMove playerTwo;

    private void Start()
    {

        
        theGameManger = FindObjectOfType<TheGameManger>();
        roundNum = theGameManger.roundNum;
        playerOneRoundsWon = theGameManger.playerOneRoundsWon;
        playerTwoRoundsWon = theGameManger.playerTwoRoundsWon;
       


    }

    public void PlayerTakesDamage(int whichPlayer)
    {
        if (whichPlayer == 1)
        {
            if (playerOneHealth > 0)
            {
                --playerOneHealth;
                playerOneHearts.AnimateHeart(playerOneHealth, true);
            }
            else
            {
                playerOne.OnDisable();
            }
        }
        else
        {
            if (playerTwoHealth > 0)
            {
                --playerTwoHealth;
                playerTwoHearts.AnimateHeart(playerTwoHealth, true);
            }
            else
            {
                playerTwo.OnDisable();
            }
        }
    }

    public void OnPlayerDeath(int playerNum) {
    
        if(playerNum == 1)
        {
            ++theGameManger.playerOneRoundsWon;
        }else
        {
            ++theGameManger.playerTwoRoundsWon;
        }

        Shake();
        CheckTheScores();


    }

    public void Shake() {
     StartCoroutine(shakeCam.ShakeMe(.5f,.1f));
    }
    public void CheckTheScores()
    {
        if(playerOneRoundsWon == NumOfRoundToWin||playerTwoRoundsWon == NumOfRoundToWin)
        {
            GameOver = true;
        }
        ko.SetActive(true);


        Invoke("GoFade", 1);
        Invoke("RoundOver", 2);

    }
    void GoFade() 
    {
        fader.FadeIn();
    }
    public void RoundOver()
    {
        ++theGameManger.roundNum;

        int leveltoLoad = 0;

        if (theGameManger.playerOneRoundsWon >= 2)
        {
            playerOneWins = true;
            leveltoLoad = 2;
        }

        if (theGameManger.playerTwoRoundsWon >= 2)
        {
            playerTwoWins = true;
            leveltoLoad = 3;
        }

      

        if (!playerOneWins && !playerTwoWins)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(leveltoLoad);
        }

    }
        
}
