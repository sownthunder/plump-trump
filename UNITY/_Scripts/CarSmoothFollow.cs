﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSmoothFollow : MonoBehaviour {

	/*
	 * Looks at a target with values to dampen height, rotation and distance (based on a rigidbody's velocity). 
	 * target = self explanatory
	 * distance = Standard distance to follow object
	 * height = The height of the camera
	 * heightDamping = Smooth out the height position
	 * lookAtHeight = An offset of the target
	 * parentRigidbody = Used to determine how far the camera should zoom out when the car moves forward
	 * rotationSnapTime = The time it takes to snap back to original rotation
	 * distanceSnapTime = The time it takes to snap back to the original distance or the zoomed distance 
	 * (depending on speed of parentRigidyBody)
	 * distanceMultiplier = Make this around 0.1f for a small zoom out or 0.5f for a large zoom 
	 * (depending on the speed of your rigidbody)
	 */

	public Transform target;
	public float distance = 20.0f;
	public float height = 5.0f;
	public float heightDamping = 2.0f;

	public float lookAtHeight = 0.0f;

	public Rigidbody parentRigidbody;

	public float rotationSnapTime = 0.3F;

	public float distanceSnapTime;
	public float distanceMultiplier;

	private Vector3 lookAtVector;

	private float usedDistance;

	float wantedRotationAngle;
	float wantedHeight;

	float currentRotationAngle;
	float currentHeight;

	Quaternion currentRotation;
	Vector3 wantedPosition;

	private float yVelocity = 0.0F;
	private float zVelocity = 0.0F;

	void Awake ()
	{



	}

	void Start () 
	{

		lookAtVector =  new Vector3(0,lookAtHeight,0);

	}

	void LateUpdate () 
	{

		wantedHeight = target.position.y + height;
		currentHeight = transform.position.y;

		wantedRotationAngle = target.eulerAngles.y;
		currentRotationAngle = transform.eulerAngles.y;

		currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);

		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		wantedPosition = target.position;
		wantedPosition.y = currentHeight;

		usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime); 

		wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);

		transform.position = wantedPosition;

		transform.LookAt(target.position + lookAtVector);

	}

}
