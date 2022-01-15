using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepMeter : MonoBehaviour
{
    public int sleepMeter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSleepMeter()
    {
        sleepMeter += 1;
    }
}