using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private int sleepMeterVictoryThreshold = 8;

    private int _sleepMeter;
    public int SleepMeter {
        get => _sleepMeter;
        set {
            if (value >= 0 && value <= sleepMeterVictoryThreshold) {
                _sleepMeter = value;
                if (Sleepometer.Instance != null){
                    Sleepometer.Instance.UpdateSleepQuantity(value);
                }
            }
        }
    }

    void Start() {
        timeManager.IsPaused = false;
        this.SleepMeter = 0;
    }

    void Update() {
        // Debug:
        if (Input.GetKeyDown("t")) {
            this.SleepMeter += 1;
        }
        if (Input.GetKeyDown("y")) {
            this.SleepMeter -= 1;
        }

        if (!timeManager.IsPaused && timeManager.NightProgress >= 1){
            // Game Over
            timeManager.IsPaused = true;
            CheckIfWon(this.SleepMeter);
        }
    }

    public void CheckIfWon(int sleepMeter) {
        if (sleepMeter >= this.sleepMeterVictoryThreshold) {
            Debug.Log("Won!!");
        } else {
            Debug.Log("LOST!!! :(");
        }
    }
}
