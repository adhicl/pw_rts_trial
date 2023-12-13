using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : MonoBehaviour
{
    private NavMeshAgent nAgent;

    void Start()
    {
        nAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetTargetPosition(Vector3 newPosition)
	{
        nAgent.SetDestination(newPosition);
	}

    public void ClearTargetPosition()
	{
        nAgent.SetDestination(this.transform.position);
	}
}
