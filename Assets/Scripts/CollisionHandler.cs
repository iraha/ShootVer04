using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("FX prefab on player")] [SerializeField] GameObject successFX;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;
    //[SerializeField] float levelLoadDelay = 2f;

    [SerializeField] GameObject gunRight;
    [SerializeField] GameObject gunLeft;
    
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject PauseButton;

    //[SerializeField] GameObject[] guns;

    // game controller
    public Joystick joystick;

    //need to chenge Number
    public string nextLevel = "Level02";
    // need to chenge Number
    public int levelUnlock = 2;

    AudioSource BGM;

    public SceneFader sceneFader;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //movingButton.SetActive(true);
        //PauseButton.SetActive(true);

        BGM = GetComponent<AudioSource>();
        BGM.Play();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Goal"))
        {
            StartSuccessSequence();
            successFX.SetActive(true);
            //Invoke("MainMenuScene", levelLoadDelay);
            gameClearUI.SetActive(true);
            PauseButton.SetActive(false);
            joystick.SetActive(false);

            gunLeft.SetActive(false);
            gunRight.SetActive(false);

            BGM.Stop();

            WinLevel();

        }
        else
        {
            StartDeathSequence();
            deathFX.SetActive(true);
            //Invoke("MainMenuScene", levelLoadDelay);
            gameOverUI.SetActive(true);
            PauseButton.SetActive(false);
            joystick.SetActive(false);

            gunLeft.SetActive(false);
            gunRight.SetActive(false);

            BGM.Stop();
        }

    }

    public void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    private void StartSuccessSequence()
    {
        SendMessage("OnPlayerSuccess");
    }


    public void WinLevel()
    {
        Debug.Log("You win!!!");
        PlayerPrefs.SetInt("levelReached", levelUnlock);
        //sceneFader.FadeTo(nextLevel);

    }

}
