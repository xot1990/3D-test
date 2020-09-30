using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class GG : MonoBehaviour
{
    public GameObject boom;
    public float moveSpeed = 2f; // скорость движения объекта
    public float verticalSpeed = 0.5f; // скорость подъема объекта (Space/Ctrl)
    Transform Player;
    Scene scene;
    public Animator Anim;
    public GameObject Menu;

    void Start()
    {
        Player = transform;
        ViewUtility.VP = GetComponent<MeshFilter>().sharedMesh.vertices.ToList();
        Camera.Target = gameObject;
    }

   
    void Update()
    {
       
        float forwardMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float sideMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Jump") * verticalSpeed * Time.deltaTime;
        Player.position += Vector3.right * forwardMove +
                            -Vector3.forward * sideMove +
                            Vector3.up * verticalMove;
        if (transform.position.y < -1)
        {
            GameObject B = Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
            Menu.SetActive(true);
            Anim.SetBool("EndLvL",true);
           
        }

    }
}
