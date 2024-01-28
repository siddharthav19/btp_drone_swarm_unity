using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    public GameObject dronePrefab;
    [SerializeField]
    private int numberOfDrones = 5;
    public float spacing = 5f;
    public float upwardForce = 500f;

    private GameObject[] drones;

    private void Start()
    {
        createDrones();
        ApplyForceToDrones();
        
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
}



