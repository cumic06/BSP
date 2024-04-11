using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Start_Handler()
    {
        StageManager.Instance.StageManagement();
        GameStateManager.Instance.gameState = GameState.Stage;
    }
    

    public void Option_Handler()
    {
        UIManager.Instance.MenuUIManagement(); 
        GameStateManager.Instance.gameState = GameState.Ready;
    }

    public void Quit_Handler()
    {
        Application.Quit();
    }
}
