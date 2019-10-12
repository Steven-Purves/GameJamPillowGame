using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;




public class Menu : MonoBehaviour
{
    public GameObject backBtn;
    public GameObject startBtn;
    public GameObject menuScreenOne;
    public GameObject menuScreenTwo;
    public GameObject menuScreenZero;
    public EventSystem m_EventSystem;
    TheGameManger theGameManger;

    public Fade fader;

    // Start is called before the first frame update
    void Start()
    {
        theGameManger = FindObjectOfType<TheGameManger>();
        theGameManger.roundNum = 0;
        theGameManger.playerTwoRoundsWon = 0;
        theGameManger.playerOneRoundsWon = 0;
        //  Cursor.visible = false;
    }

   
    public void StartGame()
    {
        fader.FadeIn();
        Invoke("Starting", 1);
       
    }
    void Starting()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
  
    public void MenuOne()
    { 
        menuScreenOne.SetActive(true);
        menuScreenTwo.SetActive(false);
    //    menuScreenZero.SetActive(false);
        m_EventSystem.SetSelectedGameObject(startBtn);
    }
    public void MenuTwo()
    {
        // backBtn.Select();
//        menuScreenZero.SetActive(false);
        menuScreenOne.SetActive(false);
        menuScreenTwo.SetActive(true);
      
        m_EventSystem.SetSelectedGameObject(backBtn);
    }

}
