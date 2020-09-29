using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Target;
    float deltaX;
    float deltaY;
    float deltaZ;
    Vector3 delta;
    
    void Start()
    {
        deltaX = transform.position.x - Target.transform.position.x;
        deltaY = transform.position.y - Target.transform.position.y;
        deltaZ = transform.position.z - Target.transform.position.z;
        delta = new Vector3(deltaX, deltaY, deltaZ);
    }

    
    void Update()
    {
        transform.position = Target.transform.position + delta;
    }

    
}
