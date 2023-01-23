using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private PlayerControler playerControllerScript; //script del que queremos informaci�n
    public float leftBound; //l�mite

    

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerControler>(); //le damso valor a la variable, para obtener la info
    }
    void Update() //accedemos a la variable
    {
        if (!playerControllerScript.gameOver)//!niegas, si no gameover, es verdadera la condicion y quiero movimeinto
        { 
            transform.Translate(Vector3.left * Time.deltaTime * speed,Space.World); //mover en global
        }
       
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))//si supera el l�mite, caja destruida,,, uso de etiqwuetas
        {
            Destroy(gameObject);
        }
    }
}
