using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private minigameHandler MinigameHandler;
    private int currentVal;

    public int maxValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MinigameHandler = FindAnyObjectByType<minigameHandler>();
        slider = GetComponent<Slider>();
        currentVal = 0;
        slider.value = currentVal;
        slider.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int ptVal)
    {
        currentVal += ptVal;
        slider.value = currentVal;
        if (currentVal == maxValue)
        {
            MinigameHandler.nextGame();
        }
    }
    
    
}
