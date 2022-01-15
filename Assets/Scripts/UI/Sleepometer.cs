using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sleepometer : MonoBehaviour
{
    public static Sleepometer Instance;

    [SerializeField] private TMP_Text _sleepQuantityText;
    [SerializeField] private int _maxSleepQuantity;
    private Slider _sleepBarSlider;

    private void Awake()
    {
        #region Singleton

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        #endregion

        _sleepBarSlider = GetComponent<Slider>();
        _sleepBarSlider.maxValue = _maxSleepQuantity;
        _sleepBarSlider.minValue = 0;
    }

    public void UpdateSleepQuantity(int currentSleep)
    {
        int clampedCurrentSleep = Mathf.Clamp(currentSleep, 0, _maxSleepQuantity);

        _sleepBarSlider.value = clampedCurrentSleep;

        if (currentSleep > GameManager.Instance.SleepometerWinThreshold)
        {
            _sleepQuantityText.text = $"{currentSleep}";
        }
        else
        {
            _sleepQuantityText.text = $"{currentSleep} / {_maxSleepQuantity}";
        }
    }
}
