using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaMenu : MonoBehaviour
{
    
    public void Rotation()
    {
        Quaternion target = Quaternion.Euler(124.44f, 0, 540.009f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
    }

    public void Scale()
    {
        if (transform.localScale != Vector3.one) transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }
}
