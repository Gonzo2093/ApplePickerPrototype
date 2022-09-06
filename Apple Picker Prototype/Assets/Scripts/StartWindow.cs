using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartWindow : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
