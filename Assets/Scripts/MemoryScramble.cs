using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryScramble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite cardBack;
    public Sprite[] cardImages;
    public Button[] cards;
    public int[] cardNumberConverter;
    
    bool flipped = false;
    public int clicks;
    Button card1;
    Button card2;

    int cardSprite1 = -1;
    int cardSprite2 = -1;
    

    void Start()
    {
        //cardListLength = cardList1.Length;
        clicks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCardValue(int num)
    {
        if(clicks == 0)
        {
            cardSprite1 = num;
        }
        if(clicks == 1)
        {
            cardSprite2 = num;
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
            print("got first card");
            return;
        }
        if(clicks == 1)
        {
            card2 = cards[cardNum];
            print("got second card");
            card2.gameObject.GetComponent<Image>().sprite = cardImages[cardSprite2];
            if (cardSprite1 == cardSprite2)
            {
                print("found a match");
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

        //Image current = card.gameObject.GetComponent<Image>();        
    }

    IEnumerator ResetCards()
    {
        yield return new WaitForSeconds(1f);
        print("not a match");
        clicks = 0;
        card1.GetComponent<Image>().sprite = cardBack;
        card2.GetComponent<Image>().sprite = cardBack;
        cardSprite1 = -1;
        cardSprite2 = -1;
        
    }


}
