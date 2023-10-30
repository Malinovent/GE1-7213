using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mali.Audio;

public class SoundTest : MonoBehaviour
{
       // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            //Play Fire Ball
            AudioManager.Singleton.PlayAudio("fireBall");
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            //Play Ice Ball
            AudioManager.Singleton.PlayAudio("iceBall");
        }
        
    }
}
