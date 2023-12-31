using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxTemperature(float temperature)
    {
        slider.maxValue = temperature;
        slider.value = 0;
    }
    public void SetTemperature(float temperature)
    {
        slider.value = temperature;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
