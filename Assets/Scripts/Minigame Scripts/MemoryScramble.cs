using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MemoryScramble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite cardBack;
    public Sprite[] cardImages;
    public Button[] cards;
    public int[] cardNumberConverter = new int[6];
    
    bool flipped = false;
    public int clicks;
    Button card1;
    Button card2;

    int cardSprite1 = -1;
    int cardSprite2 = -1;

    public Button continueButton;
    int pairs;
    minigameHandler mh;
    soundEffects se;

    void Start()
    {
        mh = GameObject.Find("scriptholder").gameObject.GetComponent<minigameHandler>();
        //cardListLength = cardList1.Length;
        clicks = 0;
        fillCardNums(cardNumberConverter);
        se = GameObject.Find("scriptholder").gameObject.GetComponent<soundEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fillCardNums(int[] numList)
    {
        //print("numList1 is " + numList.Length);
        //print("numList2 is " + cardNumberConverter.Length);
        System.Random randNum = new System.Random();
        int forceQuit = 0;
        bool numberSet = false;
        for (int i = 0; i < numList.Length; i++)
        {
            //print("i is " + i);
            forceQuit = 0;
            numberSet = false;
            while(numberSet == false)
            {
                forceQuit++;
                int newNum = randNum.Next(0, cardImages.Length);
                int numAmt = numList.Count(c => c == newNum);
                if (numAmt < 2)
                {
                    numList[i] = newNum;
                    numberSet = true;
                }
                if (forceQuit > 30)
                {
                    print("force quit used");
                    return;
                }
            }

        }
    }

    public void setCardValue(int num)
    {
        se.switchSound(11);
        if(clicks == 0)
        {
            cardSprite1 = cardNumberConverter[num];
        }
        if(clicks > 0)
        {
            cardSprite2 = cardNumberConverter[num];
        }
        else
        {
            print("too many clicks");
        }
    }

    public void flipCard(int cardNum)
    {
        //cards[num].gameObject.GetComponent<Image>().sprite = cardImages[num];
        if(clicks == 0)
        {
            print("first num" + cardSprite1);
            card1 = cards[cardNum];
            card1.gameObject.GetComponent<Image>().sprite = cardImages[cardSprite1];
            
            clicks++;
            //print("got first card");
            return;
        }
        if(clicks > 0)
        {
            card2 = cards[cardNum];
            //print("got second card");
            card2.gameObject.GetComponent<Image>().sprite = cardImages[cardSprite2];
            if(card1 == card2)
            {
                //print("same card");
                return;
            }
            else
            {
                if (cardSprite1 == cardSprite2)
                {
                    //print("found a match");
                    se.switchSound(10);
                    pairs++;
                    card1.gameObject.GetComponent<Button>().interactable = false;
                    card2.gameObject.GetComponent<Button>().interactable = false;
                    clicks = 0;
                    cardSprite1 = -1;
                    cardSprite2 = -1;
                }
                else
                {
                    StartCoroutine("ResetCards");

                }
            }

        }
        if(pairs == cardImages.Length)
        {
            //continueButton.gameObject.SetActive(true);
            StartCoroutine("winGame");
            //mh.nextGame();
        }

        //Image current = card.gameObject.GetComponent<Image>();        
    }

    IEnumerator winGame()
    {
        yield return new WaitForSeconds(0.5f);
        se.playVoice("pleasure3");
        yield return new WaitForSeconds(se.voiceover.clip.length + 0.2f);
        //print("not a match");
        mh.nextGame();

    }

    IEnumerator ResetCards()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].interactable = false;
        }
        yield return new WaitForSeconds(0.5f);
        //print("not a match");
        se.switchSound(8);
        clicks = 0;
        card1.GetComponent<Image>().sprite = cardBack;
        card2.GetComponent<Image>().sprite = cardBack;
        cardSprite1 = -1;
        cardSprite2 = -1;
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].interactable = true;
        }

    }


}
