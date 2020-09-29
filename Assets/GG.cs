using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG : MonoBehaviour
{
    public float moveSpeed = 2f; // скорость движения объекта
    public float verticalSpeed = 0.5f; // скорость подъема объекта (Space/Ctrl)
    Transform Player;

    void Start()
    {
        Player = transform;
    }

   
    void Update()
    {
       
        float forwardMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float sideMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Jump") * verticalSpeed * Time.deltaTime;
        Player.position += Vector3.right * forwardMove +
                            -Vector3.forward * sideMove +
                            Vector3.up * verticalMove;

    }
}
