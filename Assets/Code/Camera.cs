using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject StartTarget;
    public static GameObject Target;
    float deltaX;
    float deltaY;
    float deltaZ;
    Vector3 delta;
    
    void Start()
    {
        deltaX = transform.position.x - StartTarget.transform.position.x;
        deltaY = transform.position.y - StartTarget.transform.position.y;
        deltaZ = transform.position.z - StartTarget.transform.position.z;
        delta = new Vector3(deltaX, deltaY, deltaZ);
    }

    
    void Update()
    {
        if (Target != null)
        {
            transform.position = Target.transform.position + delta;
        }
    }

    
}
