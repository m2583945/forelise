using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MemoryScramble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject card1;
    public List<Image> cardList = new List<Image>{};
    
    int cardListLength = 0;
    void Start()
    {
        cardListLength = cardList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countCards()
    {
        print(cardListLength);
    }
}
