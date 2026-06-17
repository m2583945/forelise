using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer : MonoBehaviour
{
    private Camera mainCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        newPos.z += 1;
        transform.position = newPos;
    }
}
