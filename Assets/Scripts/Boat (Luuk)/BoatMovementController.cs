using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovementController : MonoBehaviour {

    [Header("Boat Settings")]

	public float initialSpeed;
	public float maxSpeed;
	public float rotationSpeed;

    [Header("Wave Settings")]

	public float waveHeight;
	public float waveSpeed;
	public float waveOffset;

    [Header("Debug Settings")]

	public bool enableVelocityDebug;
	public bool enableDrawMovementGizmo;
	
	public float horizontal;
	public float vertical;

	private float velocity;

	void Start ()
	{
		velocity = initialSpeed;
	}
	
	void Update ()
	{
		SetMovement();
	}

    private void SetMovement()
    {
		if (enableVelocityDebug)
		{
			Debug.Log("VELOCITY: " + System.Math.Round(velocity, 1));
		}

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
			if (velocity < maxSpeed)
			{
				velocity += 0.025f;
			}
		}

		else if (velocity <= initialSpeed)
		{
			velocity = initialSpeed;
		}

		else
		{
			velocity -= 0.025f;
		}
		
		// Position
		var inputDirection = new Vector3(horizontal, 0, vertical);
		var thrust = Vector3.Dot(inputDirection.normalized, transform.forward);
		transform.position += thrust * inputDirection.magnitude * transform.forward * velocity * Time.deltaTime;
		transform.position = new Vector3(transform.position.x, (waveHeight * Mathf.Sin(Time.time * waveSpeed)) + waveOffset, transform.position.z);

		// Rotation
		var rotation = Vector3.Dot(inputDirection.normalized, transform.right);
		var rotationAmount = rotationSpeed * Time.deltaTime * rotation;
		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rotationAmount, 0);
	}
	
	void OnDrawGizmos()
	{
		var directionVector = new Vector3(horizontal, 0, vertical);
		var size = Mathf.Min(1, directionVector.magnitude);

		if (enableDrawMovementGizmo)
		{
			if (size >= float.Epsilon)
			{
				Gizmos.color = Color.grey;
				Gizmos.DrawWireSphere(transform.position, 4);
				Gizmos.color = Color.white;
				Gizmos.DrawWireSphere(transform.position, size * 4);
			}

			// Draw each component of the input
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, transform.position + Vector3.right * horizontal * 4);
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * vertical * 4);
			// Show the sum of both components
			Gizmos.color = Color.white;
			Gizmos.DrawLine(transform.position, transform.position + directionVector * 4);
		}
	}
}