using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBoom : MonoBehaviour
{
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void Next()
    {
        if (scene.name == "LvL1") SceneManager.LoadScene("LvL2");
        if (scene.name == "LvL2") SceneManager.LoadScene("LvL3");
        
    }

    public void ResetLvL()
    {
        SceneManager.LoadScene(scene.name);
    }
}
