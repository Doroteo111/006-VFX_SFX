using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float jumpForce = 10f;
    private bool isOnTheGround = true; //cuando toque el suelo
    public bool gameOver; //es publico para que sea visuble para los otros scripts
    private Animator _animator; //acceso = la "_" privada de la propia variable *

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>(); //dar valor a la variable creada *
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnTheGround && !gameOver) //salto con el espacio y no podré saltar si es gameover(MUERTO)
        {
            Jump();
        }

    } 

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            /*gameOver = true;*/ //sustituimos
            GameOver();
        }else if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();
        }
      
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetBool("Death_b", true); //parametro a modificar,y el valor por el cual quieres modificarlo (true)
        _animator.SetInteger("DeathType_int", Random.Range(1,3));//se ejecuta la aniamción 1 + muertes aleatorias (poner 3 para incluir el 2)

        explosionParticle.Play(); //activar el sistema de particulas al morir
        dirtParticle.Stop();
    }

    private void Jump()
    {
        isOnTheGround = false;// dejo de tocar el suelo, si salto cambiar el valor del booleano para que sea false para no poder saltar otra vez


        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//la 1ra una fuerza constante, la 2a solo un empujón

        _animator.SetTrigger("Jump_trig"); //llamar al trigger, para que pase la transición a otra animación la de salto*

        dirtParticle.Stop();

    }
}
