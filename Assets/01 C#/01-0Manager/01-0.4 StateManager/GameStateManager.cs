using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoSingleton<GameStateManager>
{
    public GameState gameState;

    private void FixedUpdate()
    {
        GameStateManagement();
    }

    private void GameStateManagement()
    {
        if (gameState == GameState.Main)
        {
            UIManager.Instance.MainUI();
        }

        if (gameState == GameState.Stage)
        {
            Time.timeScale = 1;
            UIManager.Instance.StageUI();
        }

        if (gameState == GameState.Ready)
        {
            Time.timeScale = 0;
            UIManager.Instance.ReadyUI();
        }

        if (gameState == GameState.GameOver)
        {
            Time.timeScale = 0.25f;
            UIManager.Instance.GameOverUI();
        }
    }
}
