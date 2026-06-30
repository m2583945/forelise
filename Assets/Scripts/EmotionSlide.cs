using UnityEngine;

[CreateAssetMenu(fileName = "EmotionSlides", menuName = "Scriptable Objects/EmotionSlides")]
public class EmotionSlides : ScriptableObject
{
    public Sprite[] images;
    public enum EmotionType {HAPPY, SAD, ANGRY, SCARED}

    public EmotionType emotion;
}
