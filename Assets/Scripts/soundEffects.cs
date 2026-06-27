using UnityEngine;

public class soundEffects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource sfx;
    public AudioClip[] sounds;
    void Start()
    {
        
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
     */
    public void switchSound(int num)
    {
        sfx.clip = sounds[num];
        sfx.Play();
    }
}
