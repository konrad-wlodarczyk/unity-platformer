using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image borderImage;

    [SerializeField] private Sprite fullHealthBorder;
    [SerializeField] private Sprite seventyFiveBorder;
    [SerializeField] private Sprite fiftyBorder;
    [SerializeField] private Sprite twentyFiveBorder;
    [SerializeField] private Sprite emptyBorder;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetHealth(int current, int max)
    {
        slider.maxValue = max;
        slider.value = current;
        UpdateBorder(current, max);
    }

    private void UpdateBorder(int current, int max)
    {
        float percentage = (float)current / max;

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