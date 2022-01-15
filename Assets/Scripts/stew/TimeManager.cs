using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Progression of the night time, from 0 to 1
    public float NightProgress {
        get;
        private set;
    }
    
    [SerializeField]
    private Vector3 startingLightRotation = new Vector3(-40, 0, 0);
    [SerializeField]
    private Vector3 endingLightRotation = new Vector3(-250, 0, 0);
    [SerializeField]
    private int nightDurationSeconds = 300;
    [SerializeField]
    private Transform lightSource;
    [SerializeField]
    private Slider timeSlider;

    public bool IsPaused {
        get; set;
    }

    void Start()
    {
        this.lightSource.eulerAngles = startingLightRotation;
        
        if (this.timeSlider != null) {
            this.timeSlider.minValue = 0;
            this.timeSlider.maxValue = 1;
        }
    }

    void Update()
    {
        if (IsPaused)
            return;

        this.NightProgress += Time.deltaTime / this.nightDurationSeconds;
        Debug.Log(this.NightProgress);
        
        if (this.timeSlider != null) {
            this.timeSlider.value = this.NightProgress;
        }
        
        float new_x = Mathf.Lerp(startingLightRotation.x, endingLightRotation.x, this.NightProgress);
        float new_y = Mathf.Lerp(startingLightRotation.y, endingLightRotation.y, this.NightProgress);
        float new_z = Mathf.Lerp(startingLightRotation.z, endingLightRotation.z, this.NightProgress);
        this.lightSource.eulerAngles = new Vector3 (new_x, new_y, new_z);  
    }
}
