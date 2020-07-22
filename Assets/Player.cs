using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables n stuff
    [Tooltip("In ms^1")][SerializeField] float xSpeed = 11f;
    [Tooltip("In ms^1")] [SerializeField] float ySpeed = 9f;

    [SerializeField] float positionPitchFactor = -7f;
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float positionYawFactor = 7f;
    [SerializeField] float controlRollFactor = -25f;
    private float horizontalThrow;
    private float verticalThrow;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
}
