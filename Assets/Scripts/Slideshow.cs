using UnityEngine;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour
{
    public EmotionSlides fearSlides;
    public EmotionSlides angerSlides;
    public EmotionSlides happySlides;
    public EmotionSlides sadSlides;
    private EmotionSlides[] slides;
    private int slideIndex;
    private EmotionSlides currentSlideArray;
    private Image display;
    private Sprite image;

    public ProgressBar gameProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        display = GetComponent<Image>();
        slides = new EmotionSlides[] { fearSlides, angerSlides, happySlides, sadSlides };
        ChangeSlide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitAnswer(string emotionType)
    {
        if (emotionType.Equals("happiness") & currentSlideArray.emotion == EmotionSlides.EmotionType.HAPPY)
        {
            Debug.Log("Happy Memory");
            gameProgress.AddPoint(1);
            ChangeSlide();
        }
        else if(emotionType.Equals("sadness") & currentSlideArray.emotion == EmotionSlides.EmotionType.SAD)
        {
            Debug.Log("Sad Memory");
            gameProgress.AddPoint(1);
            ChangeSlide();
        }
        else if(emotionType.Equals("anger") & currentSlideArray.emotion == EmotionSlides.EmotionType.ANGRY)
        {
            Debug.Log("Angry Memory");
            gameProgress.AddPoint(1);
            ChangeSlide();
        }
        else if(emotionType.Equals("fear") & currentSlideArray.emotion == EmotionSlides.EmotionType.SCARED)
        {
            Debug.Log("Scary Memory"); 
            gameProgress.AddPoint(1);
            ChangeSlide();
        }
        else
        {
            gameProgress.AddPoint(-1);
            Debug.Log("Incorrect!");
        }
    }

    
    private void ChangeSlide()
    {
        int newSlideArray = slideIndex;
        while (newSlideArray == slideIndex)
        {
            newSlideArray = Random.Range(0, slides.Length);
        }
        currentSlideArray = slides[newSlideArray];
        slideIndex = newSlideArray;
        display.sprite = currentSlideArray.images[Random.Range(0, currentSlideArray.images.Length)];
    }
}
