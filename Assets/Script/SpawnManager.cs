using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab; //HACER APARECER LOS OBSTACULOS **ejercico extra ahora será array multiples objetos

    private float startDelay = 2f; //la primera llamada
    private float repeatRate = 3f; //entre llamadas

    public float gravityModifier = 1.5f; // U;

    private PlayerControler playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControler>(); 
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        Physics.gravity *= gravityModifier; // U;
    }

    private void Update()
    {
        if (playerControllerScript.gameOver) //a la que muero, el spawn para de generar
        {
            CancelInvoke("SpawnObstacle"); //a la que gameover valga true, cancela la operación
        }
    }
    private void SpawnObstacle()
    {
        int randomIdx = Random.Range(0, obstaclePrefab.Length); //número de elementos de la list prefabs
        Instantiate(obstaclePrefab[randomIdx], transform.position, obstaclePrefab[randomIdx].transform.rotation); 
        // QUE, DONDE, COMO  **el trasnform no puede ir con array, entonces indicamos que queremos el objeto que afecte al trasnform
    }

  
}

