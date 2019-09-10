using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int yourStageLevel = 1;

    private Rigidbody rb;
    //public SphereCollider collision;

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 45f;
    [Tooltip("In ms1")] [SerializeField] float xRange = 15f;
    [Tooltip("In ms1")] [SerializeField] float yRange = 11f;
    //[SerializeField] GameObject[] guns;

    [Header("ScreenPositionBased")]
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float positionYawFactor = 0.5f;

    [Header("ControlThrowBased")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -25f;




    public Joystick joystick;


    float xThrow;
    float yThrow;

    bool isControlEnabled = true;



    // Start is called before the first frame update
    void Start()
    {
        joystick.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            //ProcessFiring();
        }


    }

    // Save Player's data (start)
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        yourStageLevel = data.yourStageLevel;

    }

    // Save Player's data (end)



    void OnPlayerSuccess()
    {
        isControlEnabled = false;

        GetComponent<BoxCollider>().enabled = false;
        joystick.SetActive(false);

    }

    void OnPlayerDeath() // called by String Words
    {
        isControlEnabled = false;
        // if Player died BoxCollider would be off
        GetComponent<BoxCollider>().enabled = false;
        // if Player died, Guns would be stopped
        //DeactivateGuns();
        joystick.SetActive(false);

    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // X Horizontal
        //xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        xThrow = joystick.Horizontal;
        yThrow = joystick.Vertical;

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rowXPos = transform.localPosition.x + xOffset;
        float rowYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rowXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rowYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }



    //void ProcessFiring()
    //{

    //}


    //private void ActivateGuns()
    //{
    //foreach (GameObject gun in guns)
    //{
    //gun.SetActive(true);
    //}
    //}

    //private void DeactivateGuns()
    //{
    //foreach (GameObject gun in guns)
    //{
    //gun.SetActive(false);
    //}
    //}

}
