using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTextUpdater : MonoBehaviour
{
    private int level;

    private void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;

        GetComponent<TMP_Text>().text = "Level: " + level;
    }
}
