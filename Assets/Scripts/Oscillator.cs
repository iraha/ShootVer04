using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 30f, 5f);
    [SerializeField] float priod = 1f;

    //todo movementpercent
    //[Range(0,1)][SerializeField]
    float movementFactor; // 0 not move, 1 for fully move

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {

        startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (priod <= Mathf.Epsilon) { return; }
        float cycles = Time.time / priod; // grows continually from 0, Udemy section 61,62

        const float tau = Mathf.PI * 2; // about 6.2
        float rawSinWave = Mathf.Sin(cycles * tau);
        // Follow https://en.wikipedia.org/wiki/Turn_(geometry)#Tau_proposal
        // And https://docs.unity3d.com/ScriptReference/Mathf.Sin.html

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
