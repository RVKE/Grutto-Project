using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMouseFollow : MonoBehaviour {

	public Camera referenceCamera;

	private BoatMovementController movementController;
	Vector3 mousePosition = Vector3.zero;

    [Header("Debug Settings")]

	public bool enableDrawMouseGizmo;

	void Start ()
	{
		movementController = GetComponent<BoatMovementController>();
	}
	
	void Update ()
	{
		Vector3 shipLocation = this.transform.position;
		Ray cameraRay = referenceCamera.ScreenPointToRay(Input.mousePosition);
		var rayIterationCount = referenceCamera.transform.position.y / -cameraRay.direction.y;
		var planeSpaceMouse = new Vector3(cameraRay.origin.x + cameraRay.direction.x * rayIterationCount, 0, cameraRay.origin.z + cameraRay.direction.z * rayIterationCount);
		mousePosition = planeSpaceMouse;
		
		var direction = (mousePosition - shipLocation);
		if (direction.magnitude > 1)
		{
			direction.Normalize();
		}
		movementController.horizontal = direction.x;
		movementController.vertical = direction.z;
	}

	void OnDrawGizmos()
	{
		if (enableDrawMouseGizmo)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(mousePosition, 0.5f);
		}
	}
}
