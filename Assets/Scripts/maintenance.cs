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
    void Start()
    {
        se = GameObject.Find("scriptholder").gameObject.GetComponent<soundEffects>();
        dh = GameObject.Find("scriptholder").gameObject.GetComponent<DialogueHandler>();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rotateScrew(int num)
    {
        GameObject screw = screws[num]; 
        clicks[num]++;
        screw.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, 35);
        print("rotating");
        if (clicks[num] > 2)
        {
            screwsDone++;
            se.switchSound(1);
            screws[num].gameObject.SetActive(false);  
            if(screwsDone == 1)
            {
                dh.StartDialogue("Maintenance1", "vex");
            }
            if(screwsDone == 2)
            {
                dh.StartDialogue("Maintenance2", "vex");
            }
            if (screwsDone == 3)
            {
                dh.StartDialogue("Maintenance3", "robo");
            }
            if (screwsDone == 4)
            {
                maintenanceMinigame.gameObject.SetActive(false);
                se.switchSound(0);
                dh.StartDialogue("Maintenance4", "vex");
            }
        }
    }
}
