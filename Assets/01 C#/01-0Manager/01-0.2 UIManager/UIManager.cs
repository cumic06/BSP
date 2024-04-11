using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject TitleTxt;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject OptionHandler;
    [SerializeField] private GameObject[] MenuHandler;

    #region GameStateUI

    public void MainUI()
    {
        MenuUI.SetActive(true);
        TitleTxt.SetActive(true);
        OptionHandler.SetActive(true);
    }

    public void ReadyUI()
    {

    }

    public void StageUI()
    {
        OptionHandler.SetActive(true);
        MenuHandler[0].SetActive(false);
        MenuHandler[1].SetActive(true);
        MenuHandler[2].SetActive(true);
    }



    public void GameOverUI()
    {
        StageManager.Instance.LoadMainScene();
    }
    #endregion 

    public void MenuUIManagement()
    {
        MenuUI.SetActive(!MenuUI.activeSelf);
    }
}
