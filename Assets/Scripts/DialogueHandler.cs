using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;
using Yarn;

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
        maintenance ma;
        soundEffects se;
        minigameHandler mh;

        public Image cgbackground;
        public Sprite[] cgImages;


        // Start is called before the first frame update
        void Start()
        {

            characterName.gameObject.SetActive(true);
            ma = GameObject.Find("scriptholder").gameObject.GetComponent<maintenance>();
            se = GameObject.Find("scriptholder").gameObject.GetComponent<soundEffects>();
            mh = GameObject.Find("scriptholder").gameObject.GetComponent<minigameHandler>();
            //vs = GameObject.FindFirstObjectByType<InMemoryVariableStorage>();
            dr.AddCommandHandler<string>("setVex", setVex);
            dr.AddCommandHandler<string>("setRobo", setRobo);
            dr.AddCommandHandler<string>("noName", noName);
            dr.AddCommandHandler<string>("hideSprites", hideSprites);
            dr.AddCommandHandler<string>("endDialogue", EndDialogue);
            dr.AddCommandHandler<int>("runMaintenance", runMaintenance);
            dr.AddCommandHandler<int>("playSound", playSound);
            dr.AddCommandHandler<int>("showCG", showCG);
            print("adding commands");
            //runNode("Cutscene1");
        }

        public void addCommands()
        {
            dr.AddCommandHandler<string>("setVex", setVex);
            dr.AddCommandHandler<string>("setRobo", setRobo);
            dr.AddCommandHandler<string>("noName", noName);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void showCG(int num)
        {
            /*
             * 0 - background
             * 1 - violin
             * 2 - vexel15e hugging
             * 3 - flashback1
             */
            cgbackground.gameObject.SetActive(true);
            cgbackground.gameObject.GetComponent<Image>().sprite = cgImages[num];   
        }
        public void playSound(int num)
        {
            se.switchSound(num);
        }
        public void setRobo(string spriteName)
        {
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "EL1-5E";
            characterName.gameObject.SetActive(true);
            portrait2.gameObject.SetActive(true);
            portrait2.gameObject.GetComponent<Image>().enabled = true;
            if (cgbackground.gameObject.activeSelf == true)
            {
                cgbackground.gameObject.SetActive(false);
            }
            if (portrait.gameObject.active == true)
            {
                portrait.gameObject.SetActive(false);
                
            }
            if(spriteName == "roboNeutral")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[0];
            }
            if (spriteName == "roboClosedEyes")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[1];
            }
            if (spriteName == "roboWhiteEyes")
            {
                print("white eyes");
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[2];
            }
            if (spriteName == "roboBlackEyes")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[3];
            }
            if (spriteName == "roboScared")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[4];
            }
            if (spriteName == "roboSurprised")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[5];
            }
            if (spriteName == "roboConfused")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[6];
            }
            if (spriteName == "roboBlush")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[7];
            }
            if (spriteName == "roboHappy")
            {
                portrait2.gameObject.GetComponent<Image>().sprite = robogirl[8];
            }

            //portrait2.gameObject.GetComponent<Image>().SetNativeSize();
        }
        public void setVex(string spriteName)
        {
            if(cgbackground.gameObject.activeSelf == true)
            {
                cgbackground.gameObject.SetActive(false);
            }
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "Vex";
            characterName.gameObject.SetActive(true);
            portrait.gameObject.SetActive(true);
            portrait.gameObject.GetComponent<Image>().enabled = true;
            portrait2.gameObject.SetActive(false);

            if (spriteName == "vexNeutral")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[0];
            }
            if (spriteName == "vexThinking")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[1];
            }
            if (spriteName == "vexSurprised")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[2];
            }
            if (spriteName == "vexTired")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[3];
            }
            if (spriteName == "vexGlasses")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[4];
            }
            if (spriteName == "vexConfused")
            {
                portrait.gameObject.GetComponent<Image>().sprite = vex[5];
            }
            //portrait.gameObject.GetComponent<Image>().SetNativeSize();
        }

        void noName(string x)
        {
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }


        void setEveryone(string everyone)
        {
            characterName.GetComponent<TMPro.TextMeshProUGUI>().text = "Everyone";
            portrait.gameObject.GetComponent<Image>().enabled = false;
        }

        public void runMaintenance(int seg)
        {
            ma.activatePanel();
            ma.segment = seg;
        }
        public void maintenanceScrew()
        {
            if(ma.gameObject.active == true)
            {
                for (int i = 0; i < ma.screws.Length; i++)
                {
                    ma.screws[i].gameObject.GetComponent<Button>().interactable = true;
                }
            }

        }
        
        public void runNode(string nodeName)
        {
            StartDialogue(nodeName,"");
        }

        public void showSprites()
        {
            portrait.gameObject.SetActive(true);
            portrait2.gameObject.SetActive(true);
        }
        public void hideSprites(string x)
        {
            x = "";
            portrait.gameObject.SetActive(false);
            portrait2.gameObject.SetActive(false);
        }

        public void cutscene1()
        {
            setVex("vex");
            StartDialogue("Cutscene1","");
        }

        public void StartDialogue(string convo, string name)
        {
            dialogueSystem.gameObject.SetActive(true);
            if(name == "vex")
            {
                portrait.gameObject.GetComponent<Image>().enabled = true;
                portrait.gameObject.SetActive(true);
            }
            if(name == "robo")
            {
                portrait2.gameObject.GetComponent<Image>().enabled = true;
                portrait2.gameObject.SetActive(true);
            }
            else
            {
                print("dialogue");
            }

                isDialogueActive = true;
            dr.StartDialogue(convo);
        }
        
        public void EndDialogue(string end)
        {
            dialogueSystem.gameObject.SetActive(false);
            portrait.gameObject.GetComponent<Image>().enabled = false;
            portrait2.gameObject.GetComponent<Image>().enabled = false;
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
