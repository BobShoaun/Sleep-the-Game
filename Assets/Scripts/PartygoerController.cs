using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartygoerController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera cam;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        // agent.SetDestination(new Vector3(20, 0, 20));
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) {
        //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit)) {
        //                 agent.SetDestination(hit.point);

        //     }
        // }
        
    }
}
