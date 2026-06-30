using UnityEngine;
using System.Collections;
using Yarn.Unity;

public class soundEffects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource sfx;
    public AudioSource voiceover;
    public AudioClip[] sounds;
    public DialogueRunner dr;
    public AudioClip[] voiceovers;


    public AudioClip[] painSounds;
    public AudioClip[] pleasureSounds;
    public AudioSource gameVoice;
    void Start()
    {
        dr.AddCommandHandler<string>("playVoice", playVoice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * switchSound effectNums:
     * 0-panel open
     * 1-screw
     * 2-typing sound
     * 3-power down
     * 4-elise walks away (ending b)
     * 5 - slap (ending b)
     * 6 - zap
     * 7 - camera shutter 
     * 8 - wrong input
     * 9 - select (short)
     * 10 - select (long)
     * 11 - click
     * 12 - ow!
     * 13 - ouch!
     * 14 - tightenscrew
     * 15 - startup sound
     */
    public void switchSound(int num)
    {
        sfx.clip = sounds[num];
        sfx.Play();
    }

    public void playVoice(string sound)
    {
        if(sound == "whereami")
        {
            voiceover.clip = voiceovers[0];
            
        }
        if (sound == "isthatyou")
        {
            voiceover.clip = voiceovers[1];
            
        }
        if(sound == "welcome")
        {
            voiceover.clip = voiceovers[2];
            //StartCoroutine("roboWelcome");
        
        }
        if(sound == "mynameis")
        {
            voiceover.clip = voiceovers[3];
        }
        if(sound == "hurting")
        {
            voiceover.clip = voiceovers[4];
        }
        if(sound == "pain1")
        {
            voiceover.clip = voiceovers[5];
        }
        if (sound == "pain4")
        {
            voiceover.clip = voiceovers[8];
        }
        if (sound == "pain5")
        {
            voiceover.clip = voiceovers[9];
        }
        if (sound == "pleasure5")
        {
            voiceover.clip = voiceovers[14];
        }
        if(sound == "pleasure3")
        {
            voiceover.clip = voiceovers[15];
        }
        if(sound == "ifeelweird")
        {
            voiceover.clip = voiceovers[16];
        }
        voiceover.Play();
    }

    public void randomPainSound()
    {
        int rand1 = Random.Range(0, 4);
        if(rand1 == 1)
        {
            int rand2 = Random.Range(0, painSounds.Length);
            gameVoice.clip = painSounds[rand2];
            gameVoice.Play();
        }

    }

    public void randomPleasureSound()
    {
        int rand1 = Random.Range(0, 4);
        if (rand1 == 1)
        {
            int rand2 = Random.Range(0, pleasureSounds.Length);
            gameVoice.clip = pleasureSounds[rand2];
            gameVoice.Play();
        }

    }

    public void painSound()
    {
        gameVoice.clip = painSounds[0];
        gameVoice.Play();
    }

    public IEnumerator roboWelcome()
    {
        voiceover.clip = voiceovers[2];
        voiceover.Play();
        yield return new WaitForSeconds(voiceover.clip.length);
        voiceover.clip = voiceovers[3];
        voiceover.Play();
    }
}
