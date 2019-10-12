using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePit : MonoBehaviour
{


    public LevelManager levelManger;

    public AudioSource deathSound;


   




    private void OnTriggerEnter2D(Collider2D collision)
    {
        deathSound.Play();
        if (collision.gameObject.tag == "PlayerOne")
        {
            levelManger.OnPlayerDeath(2);
        }
        if (collision.gameObject.tag == "PlayerTwo")
        {
            levelManger.OnPlayerDeath(1);
        }

     //   Destroy(this.gameObject);
    }

}
