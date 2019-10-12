using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGameManger : MonoBehaviour
{
    public int roundNum;
    public int playerOneRoundsWon;
    public int playerTwoRoundsWon;
    public static TheGameManger instance;
    // Start is called before the first frame update
    void Start()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


}
