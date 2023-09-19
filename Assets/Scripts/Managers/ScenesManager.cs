using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ScenesManager : MonoBehaviour
{
    private int totalScenes;
    public UnityEvent OnWin;

    private void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }

    public void LoadNextScene()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) < totalScenes)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            OnWin.Invoke();
        }
    }
}
