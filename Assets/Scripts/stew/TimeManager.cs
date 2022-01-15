using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool IsPaused {
        get; set;
    }

    void Start()
    {
        this.lightSource.eulerAngles = startingLightRotation;
    }

    void Update()
    {
        if (IsPaused)
            return;

        this.NightProgress += Time.deltaTime / this.nightDurationSeconds;
        Debug.Log(this.NightProgress);
        
        float new_x = Mathf.Lerp(startingLightRotation.x, endingLightRotation.x, this.NightProgress);
        float new_y = Mathf.Lerp(startingLightRotation.y, endingLightRotation.y, this.NightProgress);
        float new_z = Mathf.Lerp(startingLightRotation.z, endingLightRotation.z, this.NightProgress);
        this.lightSource.eulerAngles = new Vector3 (new_x, new_y, new_z);  
    }
}
