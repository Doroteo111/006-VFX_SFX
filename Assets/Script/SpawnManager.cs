using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; //HACER APARECER LOS OBSTACULOS

    private float startDelay = 2f; //la primera llamada
    private float repeatRate = 3f; //entre llamadas

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, obstaclePrefab.transform.rotation); // QUE, DONDE, COMO
    }
}

