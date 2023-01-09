using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float jumpForce = 10f;
    private bool isOnTheGround = true; //cuando toque el suelo
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnTheGround) //salto con el espacio
        {
            isOnTheGround = false;//si salto cambiar el valor del booleano para que sea false para no poder saltar otra vez
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//la 1ra una fuerza constante, la 2a solo un empujón
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        isOnTheGround = true;
    }
}
