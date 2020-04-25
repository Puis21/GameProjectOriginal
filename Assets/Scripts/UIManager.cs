using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public GameObject abilityPanel;
    public GameObject interactText;
    public GameObject pauseMenuUI;
    public GameObject movementPanel;
    public GameObject shootPanel;
    public GameObject platformPanel;
    public GameObject animPanel;
    public GameObject tipPanel;


    public bool gameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        GameManager.canAct = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        GameManager.canAct = false;
    }
}
