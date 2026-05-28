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
    public Sprite[] hairArray;
    public Sprite[] dressArray;
    public Sprite[] propArray;

    public Image hair;
    public Image dress;
    public Image prop;

    public int currentHairNum;
    public int currentDressNum;
    public int currentPropNum;
    void Start()
    {
        
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
        print("current hair num is " + currentHairNum);
        hair.gameObject.GetComponent<Image>().sprite = hairArray[currentHairNum];
        hair.gameObject.GetComponent<Image>().SetNativeSize();
    }
    public void changeDress()
    {
        dress.gameObject.GetComponent<Image>().sprite = dressArray[currentDressNum];
        dress.gameObject.GetComponent<Image>().SetNativeSize();
    }
    public void changeProp()
    {
        prop.gameObject.GetComponent<Image>().sprite = propArray[currentPropNum];
        prop.gameObject.GetComponent<Image>().SetNativeSize();
    }
}
