using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    private Transform _pauseMenu;

    private void Awake()
    {
        _pauseMenu = transform.Find("PauseMenu");

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (_pauseMenu.gameObject.activeInHierarchy)
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
    }
    public void UnpauseGame()
    {
        _pauseMenu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
