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

    public void switchSound(int num)
    {
        sfx.clip = sounds[num];
        sfx.Play();
    }
}
