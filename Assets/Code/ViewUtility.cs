using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewUtility : MonoBehaviour
{
    public float VisibleAngle;
    public float VisibleRange;
    public static List<Vector3> VP;
    public GameObject Player;
    public GameObject boom;
    public GameObject Menu;
    public Animator Anim;

    void Start()
    {
        VP = new List<Vector3>();
        GetComponent<FragmentMeshCreator>().Create(VisibleAngle, VisibleRange, 10f);
    }

    
    void Update()
    {
              
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            GameObject B = Instantiate(boom, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Menu.SetActive(true);
            Anim.SetBool("EndLvL", true);
        }
    }

    

    public static Vector3 GetRotation(Vector3 forward, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        Vector3 result = new Vector3(forward.x * Mathf.Cos(rad) + forward.z * Mathf.Sin(rad), 0,
                                        forward.z * Mathf.Cos(rad) - forward.x * Mathf.Sin(rad));
        return result;
    }
}
