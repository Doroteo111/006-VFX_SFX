using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float jumpForce = 10f;
    private bool isOnTheGround = true; //cuando toque el suelo
    public bool gameOver; //es publico para que sea visuble para los otros scripts

    private Animator _animator; // la "_" privada de la propia variable
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnTheGround && !gameOver) //salto con el espacio y no podré saltar si es gameover
        {
            isOnTheGround = false;//si salto cambiar el valor del booleano para que sea false para no poder saltar otra vez
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//la 1ra una fuerza constante, la 2a solo un empujón

            _animator.SetTrigger("Jump_trig");
        }
    } 

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }


      
    }
}
