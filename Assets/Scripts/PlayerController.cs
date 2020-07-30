using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables n stuff
    [Header("General")]
    [Tooltip("In ms^1")][SerializeField] float xSpeed = 11f;
    [Tooltip("In ms^1")] [SerializeField] float ySpeed = 9f;
    [SerializeField] GameObject[] lazers;


    [Header("Screen Position Dependant")]
    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float positionYawFactor = 7f;
    

    [Header("Control Throw Dependant")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -25f;


    private float horizontalThrow;
    private float verticalThrow;

    private bool isControlEnabled = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }


    private void ProcessRotation()
    {
        // Need to rotate
        float pitch, yaw, roll;
        pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;

        yaw = transform.localPosition.x * positionYawFactor;
        roll = horizontalThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void OnPlayerDeath() // called by collision script
    {
        isControlEnabled = false;
    }

    private void ProcessTranslation()
    {
        // X Axis Calculations
        horizontalThrow = Input.GetAxis("Horizontal");
        float xFrameOffset = horizontalThrow * xSpeed * Time.deltaTime; // offset this frame
        float rawX = transform.localPosition.x + xFrameOffset;

        // Y Axis calculations
        verticalThrow = Input.GetAxis("Vertical");
        float yFrameOffset = verticalThrow * ySpeed * Time.deltaTime;
        float rawY = transform.localPosition.y + yFrameOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawX, -5.25f, 5.25f),
            Mathf.Clamp(rawY, -3.25f, 3.25f),
            transform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire"))
        {
            SetLazersActive(true);
        }
        else
        {
            SetLazersActive(false);
        }
    }


    private void SetLazersActive(bool isActive)
    {
        foreach (GameObject lazer in lazers)
        {
            var emission = lazer.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;

        }
    }
}
