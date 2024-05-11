using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;

    private PauseMenuController _pauseMenuController;
    private PlayerController _playerController;
    private LevelController _levelController;
    // Start is called before the first frame update
    void Awake()
    {
        ActivationComponent();
    }

    private void ActivationComponent()
    {
        _pauseMenuController = GameObject.Find("PauseMenuController").GetComponent<PauseMenuController>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOverWindow();
    }

    public void GameOverWindow()
    {
        if (_playerController.lifes == false) 
        {
            _playerController.DisablePlayer();
            _pauseMenuController.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            _levelController.RestartGame();
        }
    
    } 
}
