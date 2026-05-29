using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] InputActionReference clickInput;
    private bool isPlaying;
    public Sprite[] imageArray;
    public GameObject imageDisplay;
    public GameObject mainMenu;
    int imageNum = 0;
    int dialogueNum = 0;
    Camera mainCam;
    public AudioSource[] cutsceneMusic;
    //public AudioClip[] musicArray;
    AudioSource currentAudio;
    float audioTime = 0;
    public DialogueHandler dh;
    private void Awake()
    {
        //Debug.Log("hit1");
        mainCam = Camera.main;
        isPlaying = false;
        //currentAudio = cutsceneMusic[0];
    }

    private void OnEnable()
    {
        clickInput.action.Enable();
    }
    void Update()
    {
        /*if (clickInput.action.WasPressedThisFrame() && mainMenu.gameObject.activeSelf == false)
        {
            Debug.Log("mouseClick");
            imageNum += 1;
            if (imageNum < imageArray.Length)
            {
                displaySlide(imageNum);
            }
            else if (imageNum == imageArray.Length)
            {
                Debug.Log("get it");
                isPlaying = false;
            }
            Debug.Log(imageNum);
            //cutsceneMusic.Play();
        }*/
    }
    public void startCutscene()
    {
        isPlaying = true;
        //cutsceneMusic[0].Play();
        //StartCoroutine(LoadGame());
        //print("started music " + cutsceneMusic[0].isPlaying);
    }

    public void switchImage(int dialogueNum, int sceneNum)
    {
        if(sceneNum == 1)
        {
            if(dialogueNum == 1)
            {
                print("switch setting");
                imageNum += 1;
                if (imageNum < imageArray.Length)
                {
                    print("switch image");
                    displaySlide(imageNum);
                }
                dh.showSprites();
            }
        }
    }

    public void advanceImage(int sn)
    {
        
        dialogueNum++;
        print(dialogueNum);
        switchImage(dialogueNum, sn);
    }

    public void displaySlide(int slideNum)
    {
        
        imageDisplay.gameObject.GetComponent<Image>().sprite = imageArray[imageNum];
        //audioTime = currentAudio.time;
        
        switch (imageNum)
        {
            case 4:
                //print("panel 4");
                //currentAudio = cutsceneMusic[1]; 
                //cutsceneMusic[1].time = audioTime;
                StartCoroutine("FadeOut", 1);
                break;
            case 8:
                //currentAudio = cutsceneMusic[2];
                //cutsceneMusic[2].time = audioTime;
                //cutsceneMusic[2].Play();
                StartCoroutine("FadeOut", 2);
                //StartCoroutine("transitionSong", 1);
                //StartCoroutine("transitionSong", 0);
                //cutsceneMusic[1].Stop();
                break;
            case 12:
                //currentAudio = cutsceneMusic[3];
                //cutsceneMusic[3].time = audioTime;
                //cutsceneMusic[3].Play();
                StartCoroutine("FadeOut", 3);
                break;
        }
       
        
    }
    public IEnumerator FadeOut(int fadeTo)
    {
        AudioSource oldSource = cutsceneMusic[fadeTo - 1];
        AudioSource newSource = cutsceneMusic[fadeTo];
        float startVolume = oldSource.volume;
        newSource.volume = 0;
        newSource.Play();
        while (oldSource.volume > 0)
        {
            oldSource.volume -= startVolume * Time.deltaTime / 1;
            newSource.volume += startVolume * Time.deltaTime / 1;

            yield return null;
        }

        oldSource.Stop();
        oldSource.volume = startVolume;
    }
    
    IEnumerator LoadGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = !isPlaying;
            yield return null;
        }
    }
    private void OnDisable()
    {
        clickInput.action.Disable();
    }
    
    
}
