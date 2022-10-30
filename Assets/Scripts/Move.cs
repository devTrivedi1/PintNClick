using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] Transform targetPosition;
	[SerializeField] float speed;
	[SerializeField] float maxSpeed;

	Vector3 direction;

	Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		AvoidObstacles();
		if (Input.GetMouseButton(0))
		{
			SteerBehaviour();

		}

	}
	void SteerBehaviour()
	{
		direction = (targetPosition.position - transform.position).normalized;
		rb.velocity += direction * speed;
		if (direction.magnitude > maxSpeed)
		{
			rb.velocity = direction.normalized * maxSpeed;
		}
	}

	void AvoidObstacles()
	{
		direction = (targetPosition.position - transform.position).normalized;
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
		{
			if (hit.transform != transform)
			{
				direction += hit.normal * 100;
			}
		}

		Quaternion rot = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
		transform.position += transform.forward * 20 * Time.deltaTime;
	}
}
