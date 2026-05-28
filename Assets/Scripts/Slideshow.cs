using UnityEngine;

public class Slideshow : MonoBehaviour
{
    public EmotionSlide[] slides;
    private int slideIndex;
    private EmotionSlide currentSlide;
    private SpriteRenderer display;
    private Sprite image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        display = GetComponent<SpriteRenderer>();
        ChangeSlide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitAnswer(string emotionType)
    {
        if (emotionType.Equals("happiness") & currentSlide.emotion == EmotionSlide.EmotionType.HAPPY)
        {
            Debug.Log("Happy Memory");
            ChangeSlide();
        }
        else if(emotionType.Equals("sadness") & currentSlide.emotion == EmotionSlide.EmotionType.SAD)
        {
            Debug.Log("Sad Memory");
            ChangeSlide();
        }
        else if(emotionType.Equals("anger") & currentSlide.emotion == EmotionSlide.EmotionType.ANGRY)
        {
            Debug.Log("Angry Memory");
            ChangeSlide();
        }
        else if(emotionType.Equals("fear") & currentSlide.emotion == EmotionSlide.EmotionType.SCARED)
        {
            Debug.Log("Scary Memory"); 
            ChangeSlide();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    private void ChangeSlide()
    {
        int newSlide = slideIndex;
        while (newSlide == slideIndex)
        {
            newSlide = Random.Range(0, slides.Length);
        }
        currentSlide = slides[newSlide];
        slideIndex = newSlide;
        display.sprite = currentSlide.image;
    }
}
