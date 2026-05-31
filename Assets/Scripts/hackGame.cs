using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine.UI;
using TMPro;

public class hackGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject guess;
    public GameObject numpad;
    public GameObject checker;

    string guessText = "";
    string password = "1234";
    public TMP_Text[] check;
    public TMP_Text instructions;
    string currentMsg = null;
    string displayMsg = null;
    float timer = 0;
    int charIndex = 0;
    float timePerChar = 0.05f;

    bool runType = true;
    void Start()
    {
        currentMsg = ">Accessing file...\r\n>EL1-5E root access requested\r\n>Enter password:";
        guessText = guess.gameObject.GetComponent<TMP_InputField>().text.ToString();
        System.Random randNum = new System.Random();
        password = randNum.Next(1000, 9999).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && runType == true)
        {
            //print("x" + timer);
            timer += timePerChar;
            charIndex++;
            displayMsg = currentMsg.Substring(0, charIndex);
            instructions.text = displayMsg;
            if (charIndex >= currentMsg.Length)
            {
                runType = false;
                activateGame();
            }
        }

        
    }

    public void activateGame()
    {
        guess.gameObject.SetActive(true);
        numpad.gameObject.SetActive(true);      
        checker.SetActive(true);
    }

    public void inputNum(int num)
    {
        guessText += num.ToString();
        print("guessText");
        guess.gameObject.GetComponent<TMP_InputField>().text = guessText;
        if (guessText.Length == 4)
        {
            checkGuess();
            StartCoroutine("ResetField");
            
        }
    }

    IEnumerator ResetField()
    {
        yield return new WaitForSeconds(1f);
        guess.gameObject.GetComponent<TMP_InputField>().text = "";
        //print("not a match");
    }

    public void checkGuess()
    {
        for (int i = 0; i < check.Length; i++)
        {
            char j = guessText[i];
            check[i].text = j.ToString();
            if (j == password[i])
            {
                check[i].color = Color.green;
                check[i].fontStyle = FontStyles.Bold;
                continue;
            }
            if (password.Contains(j))
            {
                check[i].color = Color.yellow;
                check[i].fontStyle = FontStyles.Normal;
                print("password is " + password);
                print(guessText + " contains " + password[i]);

                continue;
            }
            if (!password.Contains(j))
            {
                check[i].color = Color.red;
                check[i].fontStyle = FontStyles.Normal;
            }
                
                
        }
        guessText = "";
    }
}
