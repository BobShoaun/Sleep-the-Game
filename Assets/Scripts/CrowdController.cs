using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent[] agents;

    [SerializeField] private float crowdRadius = 3;
    [SerializeField] private Transform[] crowdPoints;
    [SerializeField] private float minTimeChange = 10;
    [SerializeField] private float maxTimeChange = 20;

    private float timeTillNextChange;
    private bool isDone = false;
    private int prevCrowdPointIndex = 0;

    private void Awake()
    {
        agents = GetComponentsInChildren<NavMeshAgent>();
        timeTillNextChange = Time.time;
    }

    private void Update()
    {

        checkDone();

        UpdateCrowd();
    }

    private void checkDone()
    {

        foreach (var agent in agents)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f))
            {
                if (isDone)
                    break;
                
                isDone = true;
                print("done");
                timeTillNextChange = Time.time + Random.Range(minTimeChange, maxTimeChange);
                break;
            }
        }

    }

    private void UpdateCrowd()
    {
        if (!isDone) return;

        if (Time.time < timeTillNextChange)
            return;

        int crowdPointIndex = getRandomCrowdPointIndex();
        Vector3 pos = crowdPoints[crowdPointIndex].transform.position;
        foreach (var agent in agents)
        {
            Vector2 randomCircle = Random.insideUnitCircle.normalized * crowdRadius;
            agent.SetDestination(new Vector3(pos.x + randomCircle.x, 0, pos.z + randomCircle.y));
        }
        isDone = false;

    }

    private int getRandomCrowdPointIndex () {
        int index = Random.Range(0, crowdPoints.Length);
        if (index != prevCrowdPointIndex) {
            prevCrowdPointIndex = index;
            return index;
        }
        return getRandomCrowdPointIndex();
    }
}
