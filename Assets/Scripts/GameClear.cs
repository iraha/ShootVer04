using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameClear : MonoBehaviour
{
    public GameObject ui;

    public SceneFader sceneFader;


    public string menuSceneName = "Menu";
    public string nextLevel;
    public int levelToUnlock;

    public Joystick joystick;

    private void Start()
    {
        joystick.SetActive(false);
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void NextLevel()
    {
        //Toggle();
        PlayerPrefs.SetInt("leveLReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }


    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }
}
