using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using UnityEngine.UI;

public class plugScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 startPos;
    Vector3 currentPos;
    bool thisPlug = false;
    public bool matched = false;
    public int match;
    plugGame pg;
    string socketName = "";
    char socketChar = ' ';
    char matchChar = ' ';
    GameObject socket;

    int plugsDone = 0;

    void Start()
    {
        startPos = this.transform.position;
        pg = GameObject.Find("pluggame").gameObject.GetComponent<plugGame>();
        matchChar = this.gameObject.name[this.gameObject.name.Length - 1];

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Mouse.current.leftButton.isPressed && pg.currentPlug && thisPlug == true)
        {
            pg.plugSelected = true;
            Mouse.current.position.ReadValue();
            print("clicked");
            currentPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(currentPos.x, currentPos.y, 0);
            return;
        }*/


    }

    void OnMouseUp()
    {
        pg.releasePlug();
        pg.currentPlug = null;
        thisPlug = false;
        //print("socket char is " + socketChar + " and match char is " + matchChar);
        if (socketName.EndsWith(matchChar) && socket)
        {
            pg.replacePlug(match);
            matched = true;
            print("matched");
            this.gameObject.SetActive(false);
            socket.gameObject.SetActive(false);

        }
        else
        {
            
            print("not a match");
            transform.position = startPos;
        }
        

    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //print(gameObject.name.Substring(0, 5));
        if (Mouse.current.leftButton.isPressed)
        {
            pg.selectPlug(match);
            print("currently pressed");
            print("clicking on " + this.gameObject.name);
            if (gameObject.name.Length > 4 && gameObject.name.Substring(0, 4) == "plug" && pg.currentPlug == null)
            {
                pg.currentPlug = this.gameObject;
                print("current plug is null: " + pg.currentPlug);
                thisPlug = true;
            }
            else
            {
                
            }
        }
    }

    private void OnMouseDown()
    {
        
    }
    private void OnMouseExit()
    {
        pg.currentPlug = null;
        //thisPlug = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
        //print("entered");
        socketName = col.gameObject.name;
        print(socketName);
        if (socketName.StartsWith("socket"))
        {
            socket = col.gameObject;
            socketChar = socketName[name.Length];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //print("exited");
        socketName = "";
        //socketChar = ' ';
    }
}
