using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadScene("_Scene_1_StartWindow");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
