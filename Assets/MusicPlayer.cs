using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 3f;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // dont destroy the game object that the music player is attached to
    }



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
