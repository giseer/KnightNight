using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject overHud;
    public GameObject gameObj;
    public GameObject backImage;
    public AudioManager AM;

    public void OverGame()
    {
        AM.LooseSound();
        overHud.SetActive(true);
        gameObj.SetActive(false);
        backImage.SetActive(true);
    }
}
