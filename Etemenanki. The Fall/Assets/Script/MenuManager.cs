using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startGame;
    public Button settingsGame;
    public Button exitGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit() // Метод выхода из игры
    {
        Application.Quit();
        Debug.Log("You Quit");
    }

    public void DisableMainMenu() // Деактивирует кнопки главного меню
    {
       startGame.enabled = false;
       settingsGame.enabled = false;
       exitGame.enabled = false;   
    }

    public void ActiveMainMenu() // Активирует кнопки главного меню
    {
        startGame.enabled = true;
        settingsGame.enabled = true;
        exitGame.enabled = true;
    }
}
