using System;
using UnityEngine;

public class CalibrationPoint : MonoBehaviour
{
    private float syncTime = 2f;
    private float syncPercentage;
    private bool calibrating;
    private bool syncComplete;
    private SpriteRenderer _spriteRenderer;

    public Transform progressDot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        syncPercentage = 0;
        syncComplete = false;
        calibrating = false;
        progressDot.localScale = new Vector3(0,0,1);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!syncComplete)
        {
            if (calibrating)
            {
                syncPercentage += Time.deltaTime;
                if (syncPercentage > syncTime)
                {
                    syncComplete = true;
                }
            }
            else
            {
                if(syncPercentage > 0)
                    syncPercentage -= Time.deltaTime;
            }
            
            _spriteRenderer.color = Color.Lerp(Color.red, Color.green, syncPercentage);
        }
        
    }

    public bool IsCalibrated()
    {
        return syncComplete;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") & !syncComplete)
        {
            calibrating = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player") & !syncComplete)
        {
            calibrating = false;
        }
    }
}
