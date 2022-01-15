using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPlayer : MonoBehaviour
{
    private bool _spacePressed;
    private Rigidbody _rigidbody;
    private Transform _transform;
    public SleepMeter SleepMeter;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        SleepMeter = FindObjectOfType<SleepMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        _spacePressed = Input.GetKeyDown("J");
    }

    private void FixedUpdate()
    {
        if (_spacePressed)
        {
            float timeLeft = 3.0f;
            transform.RotateAround(_transform.position, Vector3.forward, 180);
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0) 
            {
                SleepMeter.UpdateSleepMeter();
                transform.RotateAround(_transform.position, Vector3.back, 180);
            }
        }
    }
}