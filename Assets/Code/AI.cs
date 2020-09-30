using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public List<Vector3> Points;
    public bool Dest;
    Vector3 CurrentPos;
    Vector3 NextPos;
    public float Speed;
   
    int y = 0;

    void Start()
    {
        NextPos = Points[y];
    }

   
    void Update()
    {
        if (transform.position == NextPos)
        {
            if (y == Points.Count - 1) Dest = false;
            if (y == 0) Dest = true;
            if (Dest) y++;            
            if (!Dest) y--;    
            
            NextPos = Points[y];
            Vector3 dest = - transform.position + NextPos;
            dest.Normalize();

            if (dest == Vector3.right) transform.rotation = Quaternion.Euler(0, 90, 0);
            if (dest == -Vector3.right) transform.rotation = Quaternion.Euler(0, -90, 0);
            if (dest == Vector3.forward) transform.rotation = Quaternion.Euler(0, 0, 0);
            if (dest == -Vector3.forward) transform.rotation = Quaternion.Euler(0, 180, 0);

            return;
        }
        else
        {
            Move(NextPos);
        }
    }

    

    public void Move(Vector3 Next)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, Next, Time.deltaTime*Speed);
        
    }
}
