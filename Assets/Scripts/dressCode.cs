using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class dressCode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] hairArray;
    public GameObject[] dressArray;
    public GameObject[] propArray;

    public Image hair;
    public Image dress;
    public Image prop;

    public int currentHairNum;
    public int currentDressNum;
    public int currentPropNum;

    minigameHandler mh;
    soundEffects se;
    void Start()
    {
        mh = GameObject.Find("scriptholder").gameObject.GetComponent<minigameHandler>();
        se = GameObject.Find("scriptholder").gameObject.GetComponent<soundEffects>();
        mh.currentGame = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flipHair(int num)
    {
        print("flip hair");
        if (num == 1)
        {
            currentHairNum++;
            if (currentHairNum == hairArray.Length)
            {
                currentHairNum = 0;
            }

        }
        else
        {
            currentHairNum--;
            if (currentHairNum == -1)
            {
                currentHairNum = hairArray.Length - 1;
            }
        }
        changeHair();
    }
    public void flipDress(int num)
    {
        print("flip Dress");
        if (num == 1)
        {
            currentDressNum++;
            if (currentDressNum == dressArray.Length)
            {
                currentDressNum = 0;
            }

        }
        else
        {
            currentDressNum--;
            if (currentDressNum == -1)
            {
                currentDressNum = dressArray.Length - 1;
            }
        }
        changeDress();
    }
    public void flipProp(int num)
    {
        print("flip prop");
        if (num == 1)
        {
            currentPropNum++;
            if (currentPropNum == propArray.Length)
            {
                currentPropNum = 0;
            }
            
        }
        else
        {
            currentPropNum--;
            if(currentPropNum == -1)
            {
                currentPropNum = propArray.Length-1;
            }
        }
        changeProp();
    }
    public void changeHair()
    {
        se.switchSound(11);
        print("current hair num is " + currentHairNum);
        deactivate("hair");
        hairArray[currentHairNum].gameObject.SetActive(true);
        //hair.gameObject.GetComponent<Image>().sprite = hairArray[currentHairNum];
        //hair.gameObject.GetComponent<Image>().SetNativeSize();
    }
    public void changeDress()
    {
        se.switchSound(11);
        deactivate("dress");
        dressArray[currentDressNum].gameObject.SetActive(true);
    }
    public void changeProp()
    {
        se.switchSound(11);
        deactivate("prop");
        propArray[currentPropNum].gameObject.SetActive(true);
    }

    public void submit()
    {

        se.switchSound(7);
        StartCoroutine("wait1sec");

        
    }

    public void deactivate(string item)
    {
        if(item == "prop")
        {
            for(int i = 0; i < propArray.Length; i++)
            {
                propArray[i].SetActive(false);  
            }
        }
        if (item == "dress")
        {
            for (int i = 0; i < dressArray.Length; i++)
            {
                dressArray[i].SetActive(false);
            }
        }
        if (item == "hair")
        {
            for (int i = 0; i < hairArray.Length; i++)
            {
                hairArray[i].SetActive(false);
            }
        }
    }
    IEnumerator wait1sec()
    {
        yield return new WaitForSeconds(1.5f);
        if(currentDressNum == 0 && currentPropNum == 0 && currentHairNum == 0)
        {
            se.playVoice("pleasure5"); //flight attendant outfit - "i feel nice"
        }
        else
        {
            if(currentPropNum == 2 && currentHairNum == 1 && currentDressNum == 3)
            {
                se.playVoice("pain5"); // elise outfit - "i don't feel well"
            }
            else
            {
                se.playVoice("pain4"); //any other combo - "i don't know about this"
            }
        }
        yield return new WaitForSeconds(se.voiceover.clip.length);
        mh.nextGame();
    }
}
