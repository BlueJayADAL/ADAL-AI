using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera ThirdPersonCamera;
    public Camera TopCamera;


    //When script is loaded
    private void Awake()
    {
        ThirdPersonCamera.enabled = true;
        TopCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            ToggleCamera();
        }
    }

    public void ToggleCamera()
    {
        if (ThirdPersonCamera.enabled)
        {
            TopCamera.enabled = true;
            ThirdPersonCamera.enabled = false;
        }
        else
        {
            ThirdPersonCamera.enabled = true;
            TopCamera.enabled = false;
        }
    }
}
