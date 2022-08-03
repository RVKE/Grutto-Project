using UnityEngine;

public class BoatController2 : MonoBehaviour
{
    [Header("Boat Settings")]

    [SerializeField] private bool movementEnabled;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float boatHeight;
    [SerializeField] private float boatHeightAnimationSpeed;
    [SerializeField] private float rotationLerpTime;
    [SerializeField] private GameObject boatModel;


    private Vector2 boatPosition;
    private Vector2 currentAccelerationVector;
    private Vector2 currentSpeedVector;


    private void Start()
    {
        boatPosition = currentSpeedVector = currentAccelerationVector = Vector3.zero;
    }

    private void Update()
    {
        if (this == null)
            return;

        SetBoatPosition();
        SetBoatRotation();

        if (!movementEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Accelerate(acceleration);
        }
    }

    private void SetBoatPosition()
    {
        currentSpeedVector += currentAccelerationVector;
        
        if (Vector3.Magnitude(currentSpeedVector) <= maxSpeed)
            boatPosition += currentSpeedVector;

        this.transform.position = new Vector3(boatPosition.x, AnimatedBoatHeight(boatHeightAnimationSpeed), boatPosition.y);
    }

    private float AnimatedBoatHeight(float speed)
    {
        // hier kan golf animatie code (misschien met een sinus functie ?? <- flushed emojienien)
        //misschien met een curve animatie? die kan je editten in de inspector 

        return boatHeight; // tijdelijk
    }

    private void SetBoatRotation()
    {
        Vector3 tijdelijkeTargetPosPlaceholder = Vector3.zero; // dit wordt muis input class of functie
        Vector3 targetPosition = new Vector3(tijdelijkeTargetPosPlaceholder.x, boatHeight, tijdelijkeTargetPosPlaceholder.z);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - this.transform.position);

        boatModel.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotationLerpTime);
    }

    private void Accelerate(float acceleration)
    {
        // hier moet acceleratie code komen
    }
}
