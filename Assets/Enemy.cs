using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public NavMeshAgent agent;

    void Awake()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        agent.updateRotation = false;

        gameObject.tag = "Enemy";
    }

    void Update()
    {
        if (playerTransform != null)
            agent.SetDestination(playerTransform.position);

        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}