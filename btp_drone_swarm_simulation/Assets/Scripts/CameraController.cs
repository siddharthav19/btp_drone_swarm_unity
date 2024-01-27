using UnityEngine;

public class cameraController : MonoBehaviour
{
    private GameObject[] drones; 


    void LateUpdate()
    {
        // Dynamically find drones during runtime
        FindDrones();

        if (drones != null && drones.Length > 0)
        {
            SetCameraPosition();
        }
    }

    void SetCameraPosition()
    {
        Vector3 midpoint = CalculateMidpoint(); // Calculate the midpoint of all drones

        // Set the camera position to look at the midpoint and move back along the camera's forward direction
        float xPosition = midpoint.x + 1f;
        float yPosition = midpoint.y + 4f;
        float zPosition = midpoint.z - 14f;
        Vector3 newPosition = new Vector3(xPosition, yPosition, zPosition);
        transform.position = newPosition;

        // Make the camera look at the midpoint
        transform.LookAt(midpoint);
    }

    void FindDrones()
    {
        // Find all GameObjects with the "Drone" tag
        drones = GameObject.FindObjectsOfType<GameObject>();
    }

    Vector3 CalculateMidpoint()
    {
        if (drones.Length == 1)
        {
            return drones[0].transform.position;
        }

        Vector3 sum = Vector3.zero;

        foreach (GameObject drone in drones)
        {
            sum += drone.transform.position;
        }

        return sum / drones.Length;
    }
}
