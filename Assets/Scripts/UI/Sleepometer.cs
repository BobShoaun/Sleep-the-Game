using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sleepometer : MonoBehaviour
{
    public static Sleepometer Instance;

    public TMP_Text SleepQuantityText;
    public int MaxSleepQuantity;
    
    private Slider _sleepBarSlider;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _sleepBarSlider = GetComponent<Slider>();
        _sleepBarSlider.maxValue = MaxSleepQuantity;
        _sleepBarSlider.minValue = 0;
    }

    public void UpdateSleepQuantity(int currentSleep)
    {
        currentSleep = Mathf.Clamp(currentSleep, 0, MaxSleepQuantity);

        _sleepBarSlider.value = currentSleep;
        SleepQuantityText.text = $"{currentSleep} / {MaxSleepQuantity}";
    }
}
