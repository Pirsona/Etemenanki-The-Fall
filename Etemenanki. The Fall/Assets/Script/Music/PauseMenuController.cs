using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu; // Объект меню паузы
    public bool isPaused = false; // Состояние меню

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        isPaused = false;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }
}
