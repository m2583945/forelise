using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class plugGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] sockets;
    public GameObject[] plugs;
    public GameObject[] fills;
    //public bool[] socketFilled;
    int numFilled = 0;
    public Sprite filledSocket;
    public bool plugSelected = false;
    public GameObject currentPlug;

    Vector3 startPos;
    Vector3 currentPos;

    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {

       if (Mouse.current.leftButton.isPressed && (currentPlug))
        {
            Mouse.current.position.ReadValue();
           //print("clicked");
            currentPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            currentPlug.transform.position = new Vector3(currentPos.x, currentPos.y, 0);
            return;
        }

    }

    public void selectPlug(int plugNum)
    {
        for (int i = 0; i < plugs.Length; i++)
        {
            if(i != plugNum-1)
            {
                plugs[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                sockets[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
           
        }
        
    }

    public void releasePlug()
    {
        for(int i = 0;i < plugs.Length;i++)
        {
            plugs[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
            sockets[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void replacePlug(int num)
    {
        numFilled++;
        fills[num - 1].gameObject.SetActive(true);
        //sockets[num-1].gameObject.GetComponent<SpriteRenderer>().sprite = filledSocket;
    }
}
