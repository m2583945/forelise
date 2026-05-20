using UnityEngine;

[CreateAssetMenu(fileName = "EmotionSlide", menuName = "Scriptable Objects/EmotionSlide")]
public class EmotionSlide : ScriptableObject
{
    public Sprite image;
    public enum EmotionType {HAPPY, SAD, ANGRY, SCARED}

    public EmotionType emotion;
}
