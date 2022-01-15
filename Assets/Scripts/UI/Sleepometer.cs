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
    [SerializeField] private Image _sleepBarFillImage;
    private int _maxSleepQuantity;
    private Slider _sleepBarSlider;

    [SerializeField] private Color _lowSleepColor;
    [SerializeField] private Color _highSleepColor;
    
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

        _sleepBarFillImage.color = _lowSleepColor;
    }

    public void UpdateSleepQuantity(int currentSleep)
    {
        // Update sleepometer text
        if (currentSleep > GameManager.Instance.SleepometerWinThreshold)
        {
            if (currentSleep > GameManager.Instance.GetHighScore())
            {
                _sleepQuantityText.text = $"{currentSleep}";
            }
            else
            {
                _sleepQuantityText.text = $"{currentSleep} / {GameManager.Instance.GetHighScore()}";
            }

            // Update sleepometer color
            _sleepBarFillImage.color = _highSleepColor;

            int clampedCurrentSleep = Mathf.Clamp(currentSleep, 0, GameManager.Instance.GetHighScore());
            _sleepBarSlider.value = clampedCurrentSleep;
        }
        else
        {
            _sleepQuantityText.text = $"{currentSleep} / {GameManager.Instance.SleepometerWinThreshold}";

            int clampedCurrentSleep = Mathf.Clamp(currentSleep, 0, GameManager.Instance.SleepometerWinThreshold);
            _sleepBarSlider.value = clampedCurrentSleep;
        }
        if (currentSleep == 4)
            loop2.TransitionTo(0f);
        if (currentSleep == 6)
            loop3.TransitionTo(0f);
        if (currentSleep == 8)
            loop4.TransitionTo(0f);

    }

}
