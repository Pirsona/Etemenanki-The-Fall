using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadNextLevel()
    {
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
        PlayerPrefs.SetInt("ñurrentLevel", 1);
        SceneManager.LoadScene(1);
    }


}
