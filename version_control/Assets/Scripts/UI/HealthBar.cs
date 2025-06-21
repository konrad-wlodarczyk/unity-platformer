using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] 
    private Slider slider;
    [SerializeField] 
    private Image borderImage;

    [SerializeField] private Sprite fullHealthBorder;
    [SerializeField] private Sprite seventyFiveBorder;
    [SerializeField] private Sprite fiftyBorder;
    [SerializeField] private Sprite twentyFiveBorder;
    [SerializeField] private Sprite emptyBorder;

    public void SetHealth(float current, float max)
    {
        slider.maxValue = max;
        slider.value = current;
        UpdateBorder(current, max);
    }

    private void UpdateBorder(float current, float max)
    {
        float percentage = current / max;

        if (percentage >= 0.75f)
            borderImage.sprite = fullHealthBorder;
        else if (percentage >= 0.5f)
            borderImage.sprite = seventyFiveBorder;
        else if (percentage >= 0.25f)
            borderImage.sprite = fiftyBorder;
        else if (percentage > 0f)
            borderImage.sprite = twentyFiveBorder;
        else
            borderImage.sprite = emptyBorder;
    }
}
