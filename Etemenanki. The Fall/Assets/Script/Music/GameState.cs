using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private int _gameSceneIndex = 1;
    public GameUI GameUI;

    private void Awake()
    {
        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_gameSceneIndex);
        GameUI.HideUI();
    }

    public void GoToSettings()
    {
        Time.timeScale = 0.0f;
        GameUI.ShowSettings();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 0.0f;
        GameUI.ShowMainMenu();
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
