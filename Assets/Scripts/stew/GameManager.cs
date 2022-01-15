using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private float sleepMeterVictoryThreshold = 0.8f;

    void Start() {
        timeManager.IsPaused = false;
    }

    void Update() {
        if (!timeManager.IsPaused && timeManager.NightProgress >= 1){
            // Game Over
            timeManager.IsPaused = true;
            CheckIfWon(0.7f);
        }
    }

    public void CheckIfWon(float sleepMeter) {
        if (sleepMeter >= this.sleepMeterVictoryThreshold) {
            Debug.Log("Won!!");
        } else {
            Debug.Log("LOST!!! :(");
        }
    }
}
