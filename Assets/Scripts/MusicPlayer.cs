using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {
        int numMusicPLayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPLayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); // dont destroy the game object that the music player is attached to
        }
    }

}
