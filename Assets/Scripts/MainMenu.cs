using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject playButton;
    public GameObject optionButton;


    // Start is called before the first frame update
    void Start()
    {
        playButton.SetActive(true);
        optionButton.SetActive(true);
    }

}
