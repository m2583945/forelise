using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class assemblyGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //public GameObject[] places;
   // public GameObject[] pieces;
    public List<GameObject> pieces;
    public List<GameObject> places;
    int finishedPieces = 0;
    public GameObject currentPiece = null;

    Vector3 startPos;
    Vector3 currentPos;

    public GameObject selectedObject;
    Vector3 offset;

    public Vector3 targetPosition;
    public Vector3 current;

    public Collider targetCollider;
    public Collider currentCollider;
    public float snapDistance = 0.2f;



    string colName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Mouse.current.leftButton.isPressed && currentPiece)
         {
             Mouse.current.position.ReadValue();
             //print("clicked");
             currentPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
             currentPiece.transform.position = new Vector3(currentPos.x, currentPos.y, 0);
             return;
         }
       // float snapDistanceSquared = snapDistance * snapDistance;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.isPressed)//check for collider. if there is a collider under the mouse, select that object
        {
            print("readvalue");
            //Mouse.current.position.ReadValue();
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            //selectedObject = targetObject.transform.gameObject;
            if (targetObject && targetObject.gameObject.name.StartsWith("piece"))
            {
                print(targetObject.gameObject.name);
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
                selectedObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
                current = selectedObject.transform.position;
            }
        }

        if (!Mouse.current.leftButton.wasReleasedThisFrame && selectedObject)
        {
            print("checking for snap");
            int indext = pieces.IndexOf(selectedObject);
            float dist = (selectedObject.transform.position - places[indext].transform.position).magnitude;
            if (dist < snapDistance)
            {
                print("snapped");
                selectedObject.transform.position = places[indext].transform.position;
                pieces[indext].gameObject.SetActive(false);
                places[indext].gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            selectedObject = null;
            checkPieces();

        }*/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.isPressed)//check for collider. if there is a collider under the mouse, select that object
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.gameObject.name.StartsWith("piece"))
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (selectedObject)
        {
            print(selectedObject.name);
            selectedObject.transform.position = mousePosition + offset;
            current = selectedObject.transform.position;

        }


        if (Mouse.current.leftButton.wasReleasedThisFrame && selectedObject)
        {
            print("released");
            int indext = pieces.IndexOf(selectedObject);
            float dist = (selectedObject.transform.position - places[indext].transform.position).magnitude;
            print("distance is " + dist + " and snapdistance is " + snapDistance);
            if (dist < snapDistance)
            {
                //print("snapped");
                //selectedObject.transform.position = places[indext].transform.position;
                pieces[indext].gameObject.SetActive(false);
                places[indext].gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            selectedObject = null;
            //checkWon();

        }
    }

    private void OnMouseUp()
    {
        if(selectedObject)
        {
            print("mouse up");
            int indext = pieces.IndexOf(selectedObject);
            float dist = (selectedObject.transform.position - places[indext].transform.position).magnitude;
            if (dist < snapDistance)
            {
                selectedObject.transform.position = places[indext].transform.position;
            }
            selectedObject = null;
            checkPieces();
        }

    }
    public void selectPiece(int pieceNum)
    {
        currentPiece = pieces[pieceNum-1];
        for (int i = 0; i < pieces.Count; i++)
        {
            if (i != pieceNum - 1)
            {
                pieces[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //places[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

        }

    }

    public void deselectPiece()
    {
        currentPiece = null;
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
            //sockets[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void checkPieces()
    {
        finishedPieces = 0;
        for(int i = 0; i < places.Count; i++)
        {
            if (places[i].gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                finishedPieces++;
                print("finished pieces: " + finishedPieces);
                if(finishedPieces >= 6)
                {
                    print("game won");
                }
            }
        }
    }

}
