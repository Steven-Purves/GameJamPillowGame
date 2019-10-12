using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Reset",5);
    }
    private void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
