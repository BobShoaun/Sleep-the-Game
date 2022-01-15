using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int SleepometerWinThreshold = 8;

    [SerializeField] private TimeManager timeManager;

    private int _sleepMeter;
    public int SleepMeter {
        get => _sleepMeter;
        set {
            if (value >= 0) {
                _sleepMeter = value;
                if (Sleepometer.Instance != null){
                    Sleepometer.Instance.UpdateSleepQuantity(value);
                }
            }
        }
    }

    private const string HIGH_SCORE_PLAYER_PREFS = "pprefs_high_score";

    private void Awake()
    {
        #region Singleton

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        #endregion
    }

    void Start() 
    {
        timeManager.IsPaused = false;
        SleepMeter = 0;
    }

    void Update() {
        // Debug:
        if (Input.GetKeyDown("t")) {
            SleepMeter += 1;
        }
        if (Input.GetKeyDown("y")) {
            SleepMeter -= 1;
        }

        if (!timeManager.IsPaused && DidGameEnd()){
            // Game Over
            timeManager.IsPaused = true;
            MenuManager.Instance.GameEnd();
            
            // High Scores
            if (!PlayerPrefs.HasKey(HIGH_SCORE_PLAYER_PREFS) || SleepMeter > PlayerPrefs.GetInt(HIGH_SCORE_PLAYER_PREFS)) {
                Debug.Log($"New High SCORE! --> {SleepMeter}");
                PlayerPrefs.SetInt(HIGH_SCORE_PLAYER_PREFS, SleepMeter);
            }
        }
    }

    public bool DidGameEnd()
    {
        return timeManager.NightProgress >= 1;
    }

    public bool DidBeatThreshold() {
        return SleepMeter >= SleepometerWinThreshold;
    }
}
