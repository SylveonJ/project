using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject RuleUI;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("GameBoard");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!!!!");
        Application.Quit();
    }

    public void SettingButton()
    {
        Settings.SetActive(true);
    }

    public void RuleButton()
    {
        RuleUI.SetActive(true);
    }
}
