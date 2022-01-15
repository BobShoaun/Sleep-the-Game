using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class Sleepometer : MonoBehaviour
{
    public static Sleepometer Instance;

    [SerializeField] private TMP_Text _sleepQuantityText;
    [SerializeField] private int _maxSleepQuantity;
    private Slider _sleepBarSlider;

    private AudioMixer mixer;
    [SerializeField]
    private AudioMixerSnapshot loop1;
    [SerializeField]
    private AudioMixerSnapshot loop2;
    [SerializeField]
    private AudioMixerSnapshot loop3;
    [SerializeField]
    private AudioMixerSnapshot loop4;
    [SerializeField]
    private AudioSource musicLoop1;
    [SerializeField]
    private AudioSource musicLoop2;
    [SerializeField]
    private AudioSource musicLoop3;
    [SerializeField]
    private AudioSource musicLoop4;
    [SerializeField]
    private AudioSource musicLullaby;

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
        if (currentSleep == 4)
            loop2.TransitionTo(0f);
        if (currentSleep == 6)
            loop3.TransitionTo(0f);
        if (currentSleep == 8)
            loop4.TransitionTo(0f);

    }

}
