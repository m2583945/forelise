using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    //the current position of the song (in seconds)
    private float songPosition;
    //the current position of the song (in beats)
    private int songPosInBeats;
    //the last whole number beat
    private int lastBeatNumber;
    //the duration of a beat
    private float secPerBeat;
    //how much time (in seconds) has passed since the song started
    private float dsptimesong;
    //beats per minute of a song
    public float bpm;
    public float beatsBeforeHit;
    public GameObject beep;
    public GameObject beepPrefab;

    //public AudioClip teeBallSound;

    private bool ballTeed;

    void Start()
    {
        //calculate how many seconds is one beat
        secPerBeat = 60f / bpm;
        //record the time when the song starts
        dsptimesong = (float)AudioSettings.dspTime;
        
        //start the song
        GetComponent<AudioSource>().Play();

        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong);
        //calculate the position in beats
        songPosInBeats = (int)(songPosition / secPerBeat);
        lastBeatNumber = songPosInBeats;
    }

    void Update()
    {
        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong);
        //calculate the position in beats
        songPosInBeats = (int)(songPosition / secPerBeat);

        
        CheckBeat();
        
        
    }

    public float GetTimeSinceLastBeat()
    {
        // calculates time since the last beat
        // subtracts time at which the last beat occurred
        
        return (float)(AudioSettings.dspTime - dsptimesong) - (lastBeatNumber * secPerBeat);
    }
    public float getSecsPerBeat()
    {
        return secPerBeat;
    }

    public bool CheckBeat()
    {
        if(songPosInBeats >= lastBeatNumber + beatsBeforeHit)
        {
            beep = Instantiate(beepPrefab);
            //GetComponent<TapSyncController>().SetNext(ball);
            lastBeatNumber = songPosInBeats;
           // GetComponent<AudioSource>().PlayOneShot(teeBallSound, .25f);
            
            print("spawn");
            return true;
        }
        
        return false;
        
    }

   
}
