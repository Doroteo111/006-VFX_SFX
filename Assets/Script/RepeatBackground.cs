using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; //anchura de una unidad de fondo
    private void Start()
    {
        startPos = transform.position; //POSICION INICIAL
        repeatWidth = GetComponent<BoxCollider>().size.x / 2f; //dividira la anchura automaticamente de cualquier fondo que se ponga
    }

    private void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
