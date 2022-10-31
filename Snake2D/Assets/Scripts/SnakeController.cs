using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.back*rotationSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
