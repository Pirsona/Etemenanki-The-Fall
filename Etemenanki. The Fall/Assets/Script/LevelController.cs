using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var newSceneIndex = currentSceneIndex + 1;
        PlayerPrefs.SetInt("currentLevel",newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);
    }

    public void LoadCurrentLevel()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(currentLevel);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("сurrentLevel", 1);
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadNextLevel();
    }
}
