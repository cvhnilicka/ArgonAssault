using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables n stuff
    [Tooltip("In ms^1")][SerializeField] float xSpeed = 9f;
    [Tooltip("In ms^1")] [SerializeField] float ySpeed = 7f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // X Axis Calculations
        float horizontalThrow = Input.GetAxis("Horizontal");
        float xFrameOffset = horizontalThrow * xSpeed * Time.deltaTime; // offset this frame
        float rawX = transform.localPosition.x + xFrameOffset;

        // Y Axis calculations
        float verticalThrow = Input.GetAxis("Vertical");
        float yFrameOffset = verticalThrow * ySpeed * Time.deltaTime;
        float rawY = transform.localPosition.y + yFrameOffset;

        transform.localPosition = new Vector3( Mathf.Clamp(rawX, -4.25f, 4.25f), 
            Mathf.Clamp(rawY, -2.25f, 2.25f), 
            transform.localPosition.z);
    }
}
