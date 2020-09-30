using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class FragmentMeshCreator : MonoBehaviour
{
    MeshFilter myMeshFilter;
    public Transform Per;
    public GameObject EmptyMesh;
    GameObject M;

    private void Start()
    {
        M = Instantiate(EmptyMesh);
        M.transform.parent = Per;
        M.transform.position = Per.position;
        myMeshFilter = M.GetComponent<MeshFilter>();
        
       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void Update()
    {
        
        
        
    }

    public virtual void Create(float angle, float distance, float step = 10f)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        Vector3 right = ViewUtility.GetRotation(Vector3.forward, angle) * distance;
        Vector3 left = ViewUtility.GetRotation(Vector3.forward, angle) * distance;
        Vector3 from = left;

        vertices.Add(Vector3.zero);
        vertices.Add(from);
        uvs.Add(Vector2.one * 0.5f);
        uvs.Add(Vector2.one);
        int triangleIdx = 3;

        for (float angleStep = -angle; angleStep < angle; angleStep += step)
        {
            Vector3 to = ViewUtility.GetRotation(Vector3.forward, angleStep) * distance; // метод ниже
            from = to;
            vertices.Add(from);
            uvs.Add(Vector2.one);
            triangles.Add(triangleIdx - 1);
            triangles.Add(triangleIdx);
            triangles.Add(0);

            triangleIdx++;
        }
        vertices.Add(right);

        uvs.Add(Vector2.one);

        Mesh mesh = new Mesh();
        mesh.name = "FragmentArea";
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
        myMeshFilter.mesh = mesh;
        M.GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}

