using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Yarn.Unity;

public class maintenance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public Vector3 rotation;
    //public float damping;

    public GameObject[] screws;
    public int[] clicks = new int[4];
    int screwsDone = 0;
    public GameObject maintenanceMinigame;
    soundEffects se;
    DialogueHandler dh;
    public int segment = 1;

    void Start()
    {
        se = GameObject.Find("scriptholder").gameObject.GetComponent<soundEffects>();
        dh = GameObject.Find("scriptholder").gameObject.GetComponent<DialogueHandler>();
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activatePanel()
    {
        maintenanceMinigame.gameObject.SetActive(true);
        for (int i = 0; i < screws.Length; i++)
        {
            screws[i].gameObject.SetActive(true);
        }
    }
    public void disableScrews()
    {
        for(int i = 0;i < screws.Length; i++)
        {
            screws[i].gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void rotateScrew(int num) //play the maintenance segments. screws come off after 2 clicks each, which sometimes also triggers dialogue. after 4 screws, move to the next dialogue segment
    {
        GameObject screw = screws[num]; 
        clicks[num]++;
        screw.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, 35);
        print("rotating");

        //segment = 2;//for testing - disable this line for live
        if(segment == 1)//play the first maintenance dialogue segment
        {
            if (clicks[num] > 2)
            {
                //disableScrews();
                screwsDone++;
                se.switchSound(1);
                screws[num].gameObject.SetActive(false);
                if (screwsDone == 4)
                {
                    
                    maintenanceMinigame.gameObject.SetActive(false);
                    se.switchSound(0);
                    dh.StartDialogue("Dialogue2", "");
                    segment++;
                    resetScrews();
                    return;
                }
            }

        }
        if(segment == 2)//play the second minigame dialogue segment
        {
            if (clicks[num] > 2)
            {
                disableScrews();
                screwsDone++;
                se.switchSound(1);
                screws[num].gameObject.SetActive(false);
                if (screwsDone == 1)
                {
                    print("start maintenance 1 dialogue");
                    dh.StartDialogue("Maintenance1", "");
                }
                if (screwsDone == 2)
                {
                    dh.StartDialogue("Maintenance2", "");
                }
                if (screwsDone == 3)
                {
                    dh.StartDialogue("Maintenance3", "");
                }
                if (screwsDone == 4)
                {
                    maintenanceMinigame.gameObject.SetActive(false);
                    se.switchSound(0);
                    dh.StartDialogue("Maintenance4", "");
                    segment++;
                    resetScrews();
                    return;
                }
            }
        }    
        if(segment == 3)
        {

        }
        if (segment == 4)
        {
            
        }

    }

    void resetScrews()
    {
        screwsDone = 0;
        for(int i = 0; i < clicks.Length; i++)
        {
            clicks[i] = 0;
        }
       
    }
}
