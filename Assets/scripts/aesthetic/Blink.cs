using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Animator blink;
    public bool blinking = false;
    int timeThrough =0;
    public string blinkBoolString;

    public void blinkVoid()
    {
        if (blinking==false)
        {
            blinking = true;
        }
    } 

    void Update()
    {
        
        if(blinking == true)
        {
            timeThrough++;
            if (timeThrough ==1){blink.SetBool(blinkBoolString, true);}
            if(timeThrough==2){timeThrough=0; blink.SetBool(blinkBoolString, false); blinking = false;}
        }
    }
}
