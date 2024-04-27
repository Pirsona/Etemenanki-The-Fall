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
    public void Quit() // ����� ������ �� ����
    {
        Application.Quit();
        Debug.Log("You Quit");
    }
    public void DisableMainMenu() // ������������ ������ �������� ����
    {
       startGame.enabled = false;
       settingsGame.enabled = false;
       exitGame.enabled = false;   
    }
    public void ActiveMainMenu() // ���������� ������ �������� ����
    {
        startGame.enabled = true;
        settingsGame.enabled = true;
        exitGame.enabled = true;
    }
}
