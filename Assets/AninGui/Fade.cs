using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator anim;

    public void FadeIn(){
        anim.SetTrigger("FadeOut");
     }


}
