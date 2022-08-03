using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Collider planeCollider;

    [SerializeField] private float movementSpeed;

    RaycastHit hit;
    Ray ray;

    void FixedUpdate()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.transform.parent.gameObject.name == "Map")
            {
                rb.AddForce(transform.forward * movementSpeed, ForceMode.Impulse);

                transform.LookAt(hit.point);
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            }
        }
    }
}
