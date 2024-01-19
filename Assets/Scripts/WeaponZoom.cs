using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class WeaponZoom : MonoBehaviour
{
    [SerializeField] int normalZoom;
    [SerializeField] int zoomValue;

    [SerializeField] float zoomOutSensitivity = 2;
    [SerializeField] float zoomInSensitivity = 0.5f;


    Rigidbody rg;
    Camera playerCam;
    RigidbodyFirstPersonController fpsController;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponentInParent<Camera>();
        playerCam.fieldOfView = normalZoom;
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {

            playerCam.fieldOfView = zoomValue;

            fpsController.mouseLook.XSensitivity = zoomInSensitivity;
            fpsController.mouseLook.YSensitivity = zoomInSensitivity;

        }
        else
        {

            playerCam.fieldOfView = normalZoom;

            fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
            fpsController.mouseLook.YSensitivity = zoomOutSensitivity;

        }

            
        
    }
}
