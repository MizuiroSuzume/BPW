using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KipAI : Pickupable
{
	NavMeshAgent agent;
	Vector3 target;

	public float waitTime;
	public float range = 10.0f;

	public float timer;

    bool canWalk = true;
	bool generatePoint;
	bool RandomPoint(Vector3 center, float range, out Vector3 result)
	{
		for (int i = 0; i < 30; i++)
		{
			Vector3 randomPoint = center + Random.insideUnitSphere * range;
			NavMeshHit hit;
			if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
			{
				result = hit.position;
				return true;
			}
		}
		result = Vector3.zero;
		return false;
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		generatePoint = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 point;
		if (timer >= waitTime)
		{
			if (RandomPoint(transform.position, range, out point))
			{
				agent.destination = point;
				waitTime = Random.Range (3, 7);
			}
			Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
		}
		if (agent.velocity.magnitude < 0.2f) 
		{
			timer += Time.deltaTime;
		} 
		else 
		{
			timer = 0;
		}
	}
    public override void OnPickup()
    {
    }

    public override void OnDrop()
    {
        timer = waitTime;
    }
}
