using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class minigameHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] minigames;
    //public bool[] gameDone;
    public GameObject gameFrame;
    int currentGame = 0;
    public DialogueRunner dr;
    DialogueHandler dh;
    public GameObject scenebg;
    void Start()
    {
        dr.AddCommandHandler<int>("startDay", startDay);
        dh = GameObject.Find("scriptholder").gameObject.GetComponent<DialogueHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDay(int day)
    {
        //play screen transition;
        scenebg.SetActive(false);
        gameFrame.SetActive(true);
        //minigames[0].gameObject.SetActive(true);
        if(day == 1)
        {
            minigames[0].gameObject.SetActive(true);
        }
        if (day == 2)
        {
            minigames[4].gameObject.SetActive(true);
        }
        if(day == 3)
        { 
        }
    }
    public void endDay(int day)
    {
        print("endday");
        scenebg.SetActive(true);
        gameFrame.SetActive(false);
        minigames[currentGame].gameObject.SetActive(false);
        if(day == 1)
        {
            dh.runMaintenance(2);
            //dh.runNode("Maintenance1");
        }
    }
    public void nextGame()
    {
        print("starting next day");
        if(currentGame == 1)
        {
            print("ending the day");
            currentGame++;
            endDay(1);
            return;
        }
        if(currentGame == 7)
        {
            currentGame++;
            endDay(2);
            return;
        }
        else
        {
            minigames[currentGame].gameObject.SetActive(false);
            currentGame++;
            //play screen transition
            minigames[currentGame].gameObject.SetActive(true);
        }

    }
}
