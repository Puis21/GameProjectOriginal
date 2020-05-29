using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartScene()
    {
        SceneManager.LoadScene(1);
        UIManager.Instance.Resume();
    }

    public void EscapeScene()
    {
        SceneManager.LoadScene(2);
        UIManager.Instance.Resume();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
