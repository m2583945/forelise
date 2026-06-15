using UnityEngine;
using UnityEngine.InputSystem;

public class assemblyPiece : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] places;
    public int thisPiece;
    int finishedPieces = 0;
    string colName="";
    assemblyGame ag;
    char pieceChar = ' ';
    void Start()
    {
        ag = GameObject.Find("assemblygameholder").gameObject.GetComponent<assemblyGame>();
        pieceChar = this.gameObject.name[this.gameObject.name.Length - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        ag.deselectPiece();
        print("checking for match with " + this.gameObject.name + colName);
        if (colName.EndsWith(pieceChar))
        {
            print("matched");
            ag.places[thisPiece-1].gameObject.GetComponent<SpriteRenderer>().enabled = true;
            ag.checkPieces();
            this.gameObject.SetActive(false);
        }
        else
        {
            print("not a match");
        }
    }

    private void OnMouseExit()
    {

        //ag.currentPiece = null;
        //thisPlug = false;
    }
    private void OnMouseOver()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            ag.selectPiece(thisPiece);
            //print("currently pressed");
            //print("clicking on " + this.gameObject.name);

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
        colName = col.gameObject.name;
        //print("entered " + colName);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //print("exited");
        colName = "";
        ag.currentPiece = null;
        //socketChar = ' ';
    }
}
