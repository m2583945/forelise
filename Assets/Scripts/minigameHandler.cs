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
    public int currentGame = 0;
    public DialogueRunner dr;
    DialogueHandler dh;
    public GameObject scenebg;
    int dayValue = 1;
    void Start()
    {
        dr.AddCommandHandler<int>("startDay", startDay);
        dh = GameObject.Find("scriptholder").gameObject.GetComponent<DialogueHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disableAllGames()
    {
        for(int i = 0; i < minigames.Length; i++)
        {
            minigames[i].SetActive(false);
        }
    }

    public void startDay(int day)
    {
        //play screen transition;
        scenebg.SetActive(false);
        gameFrame.SetActive(true);
        dayValue = day;
        //minigames[0].gameObject.SetActive(true);
        disableAllGames();
        if(day == 1)
        {
            print("day 1 start");
            minigames[0].gameObject.SetActive(true);
            return;
        }
        if (day == 2)
        {
            print("day 2 start");
            currentGame = 3;
            minigames[3].gameObject.SetActive(true);
            return;
        }
        if(day == 3)
        {
            print("day 3 start");
            minigames[5].gameObject.SetActive(true);
            return;

        }
    }
    public void endDay(int day)
    {
        print("endday");
        scenebg.SetActive(true);
        gameFrame.SetActive(false);
        minigames[currentGame].gameObject.SetActive(false);
        if(dayValue == 1)
        {
            dh.runMaintenance(2);
            //dh.runNode("Maintenance1");
        }
        if(dayValue == 2)
        {
            print("end the second day");
            dh.runMaintenance(4);
        }
        if (dayValue == 3)
        {
            dh.runMaintenance(6);
        }
    }
    public void nextGame()
    {
        print("starting next day");
        if(currentGame == 0)//needs to be 1 or 2 in final
        {
            print("ending the day");
            currentGame++;
            endDay(1);
            return;
        }
        if(currentGame == 3)//needs to be 4 in final
        {
            currentGame++;
            endDay(2);
            return;
        }
        if(currentGame == 5)//needs to be 6? in final
        {
            endDay(3);
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
