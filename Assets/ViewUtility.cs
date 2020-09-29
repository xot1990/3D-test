using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewUtility : MonoBehaviour
{
    public float VisibleAngle;
    public float VisibleRange;
    public List<Vector3> VP;
    public GameObject Player;

    void Start()
    {
        VP = new List<Vector3>();
        Player = GameObject.FindGameObjectWithTag("Player");
        VP = Player.GetComponent<MeshFilter>().sharedMesh.vertices.ToList();


    }

    
    void Update()
    {
        foreach(var point in VP)
        {
            if (IsVisibleObject(transform, point, Player, VisibleAngle, VisibleRange)) Debug.Log("1");
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }

    public static bool IsVisibleObject(Transform from, Vector3 point, GameObject target, float angle, float distance)
    {
        bool result = false;
        if (IsAvailablePoint(from, point, angle, distance))
        {
            Vector3 direction = (point - from.position);
            Ray ray = new Ray(from.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.gameObject == target)
                {
                    result = true;
                }
            }
        }
        return result;
    }

    public static bool IsAvailablePoint(Transform from, Vector3 point, float angle, float distance)
    {
        bool result = false;

        if (from != null && Vector3.Distance(from.position, point) <= distance)
        {
            Vector3 direction = (point - from.position);
            float dot = Vector3.Dot(from.forward, direction.normalized);
            if (dot < 1)
            {
                float angleRadians = Mathf.Acos(dot);
                float angleDeg = angleRadians * Mathf.Rad2Deg;
                result = (angleDeg <= angle);
            }
            else
            {
                result = true;
            }
        }
        return result;
    }

    public static Vector3 GetRotation(Vector3 forward, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        Vector3 result = new Vector3(forward.x * Mathf.Cos(rad) + forward.z * Mathf.Sin(rad), 0,
                                        forward.z * Mathf.Cos(rad) - forward.x * Mathf.Sin(rad));
        return result;
    }
}
