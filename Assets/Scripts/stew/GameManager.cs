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
            
            // High Scores
            if (SleepMeter > GetHighScore())
            {
                Debug.Log($"New High SCORE! --> {SleepMeter}");
                SetHighScore(SleepMeter);
            }

            MenuManager.Instance.GameEnd();
        }
    }

    public bool DidGameEnd()
    {
        return timeManager.NightProgress >= 1;
    }

    public bool DidBeatThreshold() {
        return SleepMeter >= SleepometerWinThreshold;
    }

    public int GetHighScore()
    {
        if (!PlayerPrefs.HasKey(HIGH_SCORE_PLAYER_PREFS))
        {
            return 0;
        }

        return PlayerPrefs.GetInt(HIGH_SCORE_PLAYER_PREFS);
    }

    public void SetHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_PLAYER_PREFS, newHighScore);
    }

    public void TogglePause() {
        timeManager.IsPaused = !timeManager.IsPaused;
    }
}
