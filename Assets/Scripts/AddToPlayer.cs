using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPlayer : MonoBehaviour
{
    private bool _jPressed;
    private Rigidbody _rigidbody;
    private Transform _transform;
    public SleepMeter SleepMeter;

    private bool sleeping = false;

    private bool interrupted;
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
        _jPressed = Input.GetKeyDown("J");
    }
    private void FixedUpdate()
    {
        if (_jPressed)
        {
            interrupted = false;
            sleeping = true;
            float timeLeft = 3.0f;
            transform.RotateAround(_transform.position, Vector3.forward, 180);
            timeLeft -= Time.deltaTime;

            Collider[] hitColliders = Physics.OverlapSphere(_transform.position, 3);
            // for (int i = 0; i < sizeof(hitColliders); i++) {
            //     if (hitColliders[i].tag == "partypeople"){
            //         timeLeft = -1;
            //         sleeping = false;
            //         break;
            //     }
            // }
            if (hitColliders) 
            {
                timeLeft = -1;
                sleeping = false;
            }

            if (timeLeft < 0) 
            {
                if (sleeping)
                {
                    SleepMeter.UpdateSleepMeter(); 
                    sleeping = false;
                }
                transform.RotateAround(_transform.position, Vector3.back, 180);
            }
        }
    }
}



// public class Example : MonoBehaviour
// {
//     //Assign a GameObject in the Inspector to rotate around
//     public GameObject target;

//     void Update()
//     {
//         // Spin the object around the target at 20 degrees/second.
//         transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
//     }
// }

// public class TimerTest : MonoBehaviour {
//     [SerializeField] private float _duration = 1f;
//     private float _timer = 0f;
 
//     private void Update() {
//         _timer += Time.deltaTime;
//         if (_timer >= _duration) {
//             _timer = 0f;
//             // Do Stuff here
//         }
//     }
// }