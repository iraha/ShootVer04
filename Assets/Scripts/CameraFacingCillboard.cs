using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingCillboard : MonoBehaviour
{

    public Camera m_Camera;

    // Update is called once per frame
    void Update() 
    {

        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);

    }
}
