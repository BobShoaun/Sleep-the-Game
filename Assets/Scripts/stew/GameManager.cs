using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private int sleepMeterVictoryThreshold = 10;

    //TODO: add serializeField to be able to read in sleep meter.

    void Start() {
        timeManager.IsPaused = false;
    }

    void Update() {
        if (!timeManager.IsPaused && timeManager.NightProgress >= 1){
            // Game Over
            timeManager.IsPaused = true;
            CheckIfWon(7);
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
