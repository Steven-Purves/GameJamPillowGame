using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour
{
    public float time = 2;
    private void Start()
    {
        Invoke("DestoryTheStartBlock", time);
    }
    public void DestoryTheStartBlock()
    {
        Destroy(this.gameObject);
    }


}
