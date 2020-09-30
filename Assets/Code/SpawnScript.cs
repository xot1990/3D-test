using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject GG;
    public GameObject Boom;
    GameObject Menu;

    void Start()
    {
        Menu = GameObject.FindGameObjectWithTag("Menu");
        Menu.SetActive(false);
        StartCoroutine(Spawn());
    }

    
   IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        GameObject B = Instantiate(Boom,transform.position,transform.rotation);
        yield return new WaitForSeconds(0.5f);
        GameObject G = Instantiate(GG, transform.position, transform.rotation);
        G.GetComponent<GG>().Menu = Menu;
        G.GetComponent<GG>().Anim = Menu.GetComponent<Animator>();
        Destroy(gameObject);
    }
}
