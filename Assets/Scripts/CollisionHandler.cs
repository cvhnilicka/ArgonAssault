using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // make sure its the only script that loads screens

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("in seconds")][SerializeField] float levelLoadDelay = 1f;


    [SerializeField] ParticleSystem deathFx;

    [Tooltip("particle explosion object")] [SerializeField] GameObject explosionObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Player Collided with something");
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        explosionObject.SetActive(true);
        // need to disable controls 
        SendMessage("OnPlayerDeath");
        Invoke("LoadScene", levelLoadDelay);

    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
