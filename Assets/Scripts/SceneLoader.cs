using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 3f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);

    }
}
