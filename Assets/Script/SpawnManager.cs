using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; //HACER APARECER LOS OBSTACULOS

    private float startDelay = 2f; //la primera llamada
    private float repeatRate = 3f; //entre llamadas

    private PlayerControler playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControler>(); 
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void Update()
    {
        if (playerControllerScript.gameOver) //a la que muero, el spawn para de generar
        {
            CancelInvoke("SpawnObstacle");
        }
    }
    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, transform.position, obstaclePrefab.transform.rotation); // QUE, DONDE, COMO
    }
}

