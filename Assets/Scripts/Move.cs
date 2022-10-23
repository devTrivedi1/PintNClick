using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	[SerializeField] Transform moveToTarget;
	[SerializeField] Camera gameCamera;
	[SerializeField] LayerMask ground;

	[SerializeField] float speed;


	Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{

			FollowTarget();
		}
	}

	void FollowTarget()
	{
		Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, ground))
		{
			if(hitInfo.collider.tag == "Ground")
            {
                MovePlayer();
            }

		}
	}

    void MovePlayer()
    {
       
    }
}
