using UnityEngine;
using UnityEngine.AI;

public class RandomRoaming : MonoBehaviour
{
    public NavMeshAgent agent;
    public float roamingRadius = 10f;
    public float waitTime = 3f;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = waitTime;  // Start the timer
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            Vector3 newDestination = RandomNavSphere(transform.position, roamingRadius, -1);
            agent.SetDestination(newDestination);
            timer = 0; // Reset the timer after setting a new destination
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance + origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
