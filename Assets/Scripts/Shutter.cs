using UnityEngine;

public class Shutter : MonoBehaviour
{
    private Animator animator;

    public RectTransform shutterObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenShutter()
    {
        animator.SetBool("screenOn", true);
    }

    public void setShutterAnchor(float shutterHeight)
    {
        Vector3 newAnchor = shutterObj.anchoredPosition;
        newAnchor.y = shutterHeight;
        shutterObj.anchoredPosition = newAnchor;
    }
}
