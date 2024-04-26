using UnityEngine;

public class ElevatorDoors : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float openDistance = 2f;  // How much the doors should open
    public float speed = 2f;         // Speed of the doors opening and closing

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;
    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;
    private bool isOpening = false;

    void Start()
    {
        // Initialize door positions
        leftClosedPosition = leftDoor.position;
        rightClosedPosition = rightDoor.position;

        // Calculate open positions based on the closed positions and open distance
        // Adjust these lines to use the z-coordinate for movement
        leftOpenPosition = new Vector3(leftClosedPosition.x, leftClosedPosition.y, leftClosedPosition.z - openDistance);
        rightOpenPosition = new Vector3(rightClosedPosition.x, rightClosedPosition.y, rightClosedPosition.z + openDistance);
    }

    void OnTriggerEnter(Collider other)
    {
        // Start opening the doors when something enters the trigger
        isOpening = true;
    }

    void OnTriggerExit(Collider other)
    {
        // Start closing the doors when something exits the trigger
        isOpening = false;
    }

    void Update()
    {
        if (isOpening)
        {
            // Move doors to open position along the z-axis
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftOpenPosition, Time.deltaTime * speed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightOpenPosition, Time.deltaTime * speed);
        }
        else
        {
            // Move doors to closed position along the z-axis
            leftDoor.position = Vector3.Lerp(leftDoor.position, leftClosedPosition, Time.deltaTime * speed);
            rightDoor.position = Vector3.Lerp(rightDoor.position, rightClosedPosition, Time.deltaTime * speed);
        }
    }
}
