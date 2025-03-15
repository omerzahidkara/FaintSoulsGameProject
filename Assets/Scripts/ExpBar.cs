
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour // oyuncu i�in
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public Text expText; // Can miktar�n� g�steren yaz�

    public void SetMaxExp(int exp)
    {
        slider.maxValue = exp;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetExp(int exp)
    {
        slider.value = exp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        UpdateExpText(exp);

    }

    public void UpdateExpText(int currentExp)
    {
        expText.text = currentExp + " / " + slider.maxValue; // Say�y� g�ncelle
    }
}
