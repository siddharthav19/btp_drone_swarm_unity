using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    public GameObject dronePrefab;
    [SerializeField]
    private int numberOfDrones = 5;
    public float spacing = 5f;
    public float upwardForce = 1000f;
    private float highestPosition = 0f;

    private GameObject[] drones;

    private void Start()
    {
        createDrones();
        ApplyForceToDrones();
    }

    private void FixedUpdate()
    {
        StopDrones();
    }

    private void createDrones()

    {
        drones = new GameObject[numberOfDrones];

        GameObject mainDrone = gameObject;
        drones[0] = mainDrone;

        print("drone created");

        for (int i = 1; i <= numberOfDrones - 1; i++)
        {
            GameObject newDrone = Instantiate(dronePrefab, mainDrone.transform.position + new Vector3(i * spacing, 0, 0), Quaternion.identity);
            drones[i] = newDrone;

            newDrone.transform.rotation = Quaternion.identity; // Set rotation if needed
            // newDrone.transform.parent = transform; // Set parent if needed
        }



    }

    private void ApplyForceToDrones()
    {
        foreach (GameObject drone in drones)
        {
            Rigidbody droneRigidbody = drone.GetComponent<Rigidbody>();

            if (droneRigidbody != null)
            {
                droneRigidbody.AddForce(Vector3.up * upwardForce, ForceMode.Force);
            }
            else
            {
                Debug.LogError("Rigidbody component not found on the drone.");
            }
        }
    }

    private void StopDrones()
    {
        foreach (GameObject drone in drones)
        {
            Rigidbody droneRigidbody = drone.GetComponent<Rigidbody>();

            if (droneRigidbody != null)
            {

                // Check if the current position is higher than the highest position
                if (drone.transform.position.y > highestPosition)
                {
                    highestPosition = drone.transform.position.y;
                }

                // Check if the drone is close to its highest position, then apply a counterforce
                if (drone.transform.position.y == highestPosition)
                {
                    float counterGravityForce = droneRigidbody.mass * Mathf.Abs(Physics.gravity.y);
                    droneRigidbody.AddForce(Vector3.down * counterGravityForce, ForceMode.Force);
                }
                
            }
            else
            {
                Debug.LogError("Rigidbody component not found on the drone.");
            }
        }
    }
}



