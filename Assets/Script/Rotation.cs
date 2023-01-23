using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 200f;

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

}
