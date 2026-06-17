using UnityEngine;

public class TapSyncController : MonoBehaviour
{
    public BeatManager songManager;
    public float tapThreshold = 0.1f; //change to whatever we want
    public Animator tapAnimator;
    /*
    private Football ball;
    private Football nextBall;
    */
    private void Start()
    {
        
        // check if song manager component is null.
        if (songManager == null)
        {
            // attach the song manager script to game object
            songManager = gameObject.AddComponent<BeatManager>();
        }
        // check if animator component is null.
        if (tapAnimator == null)
        {
            // attach the animator to game object
            tapAnimator = gameObject.AddComponent<Animator>();
        }
        
    }


    void Update()
    {
        // get time since last beat from the song manager script
        float timeSinceLastBeat = songManager.GetTimeSinceLastBeat();
        if (Input.GetKeyDown(KeyCode.Space) && InStrikeZone(timeSinceLastBeat))
        {

            // check if the tap is on time, late, or early
            if (Mathf.Abs(timeSinceLastBeat) < tapThreshold)
            {
                //tapAnimator.SetTrigger("OnTimeTrigger"); // trigger on time animation
                
                Debug.Log("Perfect Beep");
            }
            else if (timeSinceLastBeat > 0 && timeSinceLastBeat < tapThreshold * 2)
            {
                //tapAnimator.SetTrigger("LateTrigger"); // trigger late animation
                
                Debug.Log("Late");
            }
            else
            {
                //tapAnimator.SetTrigger("EarlyTrigger"); // trigger early animation
                
                Debug.Log("Early");
            }
            //next beep
        }
        if(!InStrikeZone(timeSinceLastBeat))
        {
            if(timeSinceLastBeat >= tapThreshold)
            {
                Debug.Log("Miss");
            }
        }
        
    }

    public bool InStrikeZone(float timeSinceLastBeat)
    {
        
        if(timeSinceLastBeat >= songManager.getSecsPerBeat() - tapThreshold || timeSinceLastBeat <= tapThreshold)
        {
            return true;
        }
        else 
        {
            return false;
        }
    } 
    
    /*
    public void SetNext(GameObject newBall)
    {
        if(ball == null)
        {
            ball = newBall.GetComponent<Football>();
        }
        else 
        {
            nextBall = newBall.GetComponent<Football>();
        }
    }
    */
}