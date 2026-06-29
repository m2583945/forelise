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
    bool unscrew = false;
    soundEffects se;
    DialogueHandler dh;
    public int segment = 1;
    public int maintenanceDialogue = 1;
    bool open = true;

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

    }
    public void disableScrews()
    {
        for(int i = 0;i < screws.Length; i++)
        {
            screws[i].gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void enableScrews()
    {
        for (int i = 0; i < screws.Length; i++)
        {
            if (clicks[i] != 2)
            {
                screws[i].gameObject.GetComponent<Button>().interactable = true;
            }
            else
            {
                screws[i].gameObject.GetComponent<Button>().interactable = false;   
            }
            
        }
    }
    public void prepPanel(string task)
    {
        if(task == "open")
        {
            open = true;
            for (int i = 0; i < screws.Length; i++)
            {
                transform.rotation = Quaternion.identity;
                screws[i].gameObject.SetActive(true);
                
            }
            return;
        }
        if(task == "close")
        {
            open = false;
            for (int i = 0; i < screws.Length; i++)
            {
                screws[i].gameObject.SetActive(false);
                screws[i].transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, 70);
            }
            screws[0].gameObject.SetActive(true);
        }
   
    }
    public void rotateScrew(int num) //play the maintenance segments. screws come off after 2 clicks each, which sometimes also triggers dialogue. after 4 screws, move to the next dialogue segment
    {
        if (clicks[num] >= 3)
        {
            return;
        }
        GameObject screw = screws[num]; 
        clicks[num]++;
        string maintenanceString = "Dialogue";
        
        if(segment == 1)
        {
            print("segment is 1");
            screw.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, 35);
            if (clicks[num] > 2)
            {
                screwsDone++;
                //maintenanceDialogue++;
                se.switchSound(1);
                screws[num].gameObject.SetActive(false);
                if (screwsDone == 4)
                {

                    maintenanceMinigame.gameObject.SetActive(false);
                    se.switchSound(0);
                    dh.StartDialogue("Dialogue2", "");
                    //segment++;
                    resetScrews();
                    return;
                }
            }
            return;
        }
        else
        {
            if (open == true)
            {
                screw.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, 35);
                if (clicks[num] > 2)
                {
                    screwsDone++;
                    maintenanceDialogue++;
                    se.switchSound(1);
                    screws[num].gameObject.SetActive(false);
                    maintenanceString = "Maintenance" + maintenanceDialogue.ToString();
                    disableScrews();
                    dh.StartDialogue(maintenanceString, "");
                    if (screwsDone == 4)
                    {

                        maintenanceMinigame.gameObject.SetActive(false);
                        se.switchSound(0);
                        //dh.StartDialogue("Dialogue2", "");
                        segment++;
                        resetScrews();
                        return;
                    }

                }
            }
            else
            {
                screw.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, -120);
                print("working to close panel");
                if (clicks[num] > 2)
                {

                    screwsDone++;
                    maintenanceDialogue++;
                    se.switchSound(1);
                    screws[num].gameObject.GetComponent<Button>().interactable = false;
                    maintenanceString = "Maintenance" + maintenanceDialogue.ToString();
                    dh.StartDialogue(maintenanceString, "");
                    if (screwsDone == 4)
                    {

                        maintenanceMinigame.gameObject.SetActive(false);
                        se.switchSound(0);
                        //dh.StartDialogue("Dialogue2", "");
                        segment++;
                        resetScrews();
                        return;
                    }
                    else
                    {
                        print("not done screwing");
                        screws[num + 1].gameObject.SetActive(true);
                        screws[num + 1].gameObject.GetComponent<Button>().interactable = true;
                    }
                    print("mamd is " + maintenanceDialogue.ToString());

                }
            }

        }
        
        /*
        //segment = 2;//for testing - disable this line for live
        if (segment == 1)//play the first maintenance dialogue segment
        {
            if (clicks[num] > 2)
            {
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
            maintenanceDialogue = 1;

            if (clicks[num] > 2)
            {
                disableScrews();
                screwsDone++;
                maintenanceDialogue++;
                se.switchSound(1);
                screws[num].gameObject.SetActive(false);
                if (screwsDone == 4)
                {
                    maintenanceMinigame.gameObject.SetActive(false);
                    se.switchSound(0);
                    //dh.StartDialogue("Maintenance4", "");
                    segment++;
                    resetScrews();
                    return;
                }
                maintenanceString = "Maintenance" + maintenanceDialogue.ToString();
                dh.StartDialogue(maintenanceString, "");
            }
        }    
        if(segment == 3)
        {
            int maintenanceDialogue = 5;
            if (clicks[num] > 2)
            {

                disableScrews();
                screwsDone++;
                se.switchSound(1);
                screws[num].gameObject.SetActive(false);
                maintenanceDialogue++;
                if (screwsDone == 1)
                {
                    print("start maintenance 1 dialogue");
                    dh.StartDialogue("Maintenance5", "");
                }
                if (screwsDone == 2)
                {
                    dh.StartDialogue("Maintenance6", "");
                }
                if (screwsDone == 3)
                {
                    dh.StartDialogue("Maintenance7", "");
                }
                if (screwsDone == 4)
                {
                    maintenanceMinigame.gameObject.SetActive(false);
                    se.switchSound(0);
                    dh.StartDialogue("Maintenance8", "");
                    segment++;
                    resetScrews();
                    return;
                }
            }
        }
        if (segment == 4)
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
                    dh.StartDialogue("Maintenance9", "");
                }
                if (screwsDone == 2)
                {
                    dh.StartDialogue("Maintenance10", "");
                }
                if (screwsDone == 3)
                {
                    dh.StartDialogue("Maintenance11", "");
                }
                if (screwsDone == 4)
                {
                    maintenanceMinigame.gameObject.SetActive(false);
                    se.switchSound(0);
                    dh.StartDialogue("Maintenance12", "");
                    segment++;
                    resetScrews();
                    return;
                }
            }
        }*/

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
