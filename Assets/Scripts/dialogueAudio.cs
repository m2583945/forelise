using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueAudio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aud;

    public AudioClip vexSound;
    public AudioClip roboSound;
    public AudioClip eliseSound;


    public TextMeshProUGUI nameBox;
    void Start()
    {
        aud = this.gameObject.GetComponent<AudioSource>();
        //playSound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSound()//play the sound effect UNLESS it's already being played
    {
        if (nameBox.text.ToLower() == "vex")
        {
            aud.clip = vexSound;
        }
        if (nameBox.text.ToLower() == "el1-5e")
        {
            aud.clip = roboSound;
        }
        if (nameBox.text.ToLower() == "elise")
        {
            aud.clip = eliseSound;
        }
        else
        {
            //don't play!
        }
    }
}
