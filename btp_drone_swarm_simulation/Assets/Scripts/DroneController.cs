using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    public GameObject dronePrefab;
    [SerializeField]
    private int numberOfDrones = 5;
    public float spacing = 5f;
    private GameObject[] drones;

    private void Start()
    {
          createDrones();
    }

    private void createDrones()

    {
        drones = new GameObject[numberOfDrones-1];

        GameObject mainDrone = gameObject;
        drones[0] = mainDrone;

        for (int i = 1; i <= numberOfDrones - 1; i++)
        {
            GameObject newDrone = Instantiate(dronePrefab, mainDrone.transform.position + new Vector3(i * spacing, 0, 0), Quaternion.identity);
            drones[i-1] = newDrone;

            newDrone.transform.rotation = Quaternion.identity; // Set rotation if needed
            // newDrone.transform.parent = transform; // Set parent if needed
        }



    }

    void FixedUpdate()
    {
        
        
    }
}