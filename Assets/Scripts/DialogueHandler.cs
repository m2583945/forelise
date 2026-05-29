using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using UnityEngine.UI;
using TMPro;

namespace Yarn.Unity
{
    public class DialogueHandler : MonoBehaviour
    {
        bool lockVisited;
        public DialogueRunner dr;
        public GameObject dialogueSystem;
        public List<GameObject> disabledDuringDialogue;
        private bool isDialogueActive;
        public bool allowClicks = true;
        public Animator spriteAnimator;
        public Image portrait;
        public Image portrait2;
        public Sprite[] vex;
        public Sprite[] robogirl;
        public GameObject characterName;
        // Start is called before the first frame update
        void Start()
        {

            characterName.gameObject.SetActive(true);
            //vs = GameObject.FindFirstObjectByType<InMemoryVariableStorage>();
            dr.AddCommandHandler<string>("setVex", setVex);
            dr.AddCommandHandler<string>("setRobo", setRobo);
            //runNode("Cutscene1");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void setRobo(string spriteName)
        {
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "EL1-5E";
            characterName.gameObject.SetActive(true);
            if(portrait.gameObject.active == true)
            {
                //portrait.gameObject.SetActive(false);
                portrait2.gameObject.SetActive(true);
            }
            if(spriteName == "robo")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[0];
            }
            
            //portrait2.gameObject.GetComponent<Image>().SetNativeSize();
        }

        void setVex(string spriteName)
        {
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "Vex";
            characterName.gameObject.SetActive(true);
            if (portrait2.gameObject.active == true)
            {
                //portrait2.gameObject.SetActive(false);
                portrait.gameObject.SetActive(true);
            }
            portrait.gameObject.GetComponent<Image>().sprite = vex[0];
            if (spriteName == "vexSad")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[1];
            }
            //portrait.gameObject.GetComponent<Image>().SetNativeSize();
        }




        void setEveryone(string everyone)
        {
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "Everyone";
            portrait.gameObject.GetComponent<Image>().enabled = false;
        }
        
        public void runNode(string nodeName)
        {
            StartDialogue(nodeName);
        }

        public void showSprites()
        {
            portrait.gameObject.SetActive(true);
            portrait2.gameObject.SetActive(true);
        }
        public void hideSprites()
        {
            portrait.gameObject.SetActive(false);
            portrait2.gameObject.SetActive(false);
        }

        public void cutscene1()
        {
            setVex("vex");
            StartDialogue("Cutscene1");
        }

        private void StartDialogue(string convo)
        {
            dialogueSystem.gameObject.SetActive(true);
            portrait.gameObject.GetComponent<Image>().enabled = true;
            isDialogueActive = true;
            dr.StartDialogue(convo);
        }
        
        public void EndDialogue(string end)
        {
            dialogueSystem.gameObject.SetActive(false);
            portrait.gameObject.GetComponent<Image>().enabled = false;
            isDialogueActive = false;
        }
        
        public bool isActive()
        {
            return isDialogueActive;
        }
       
        public void allowObjectClicks()
        {
            print("allow");
            allowClicks = true;
        }
        public void disableClicks()
        {
            allowClicks = false;
        }

    }
}
