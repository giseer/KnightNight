using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorBehavior : MonoBehaviour
{
    public LayerMask playerLayer;
    public Sprite openDoor;
    public Sprite closeDoor;

    public TimerBehaviour TB;
    public KeyManager KeyM;
    public ScenesManager ScM;
    public AudioManager AM;

    private void Start()
    {
        closeDoor = GetComponent<SpriteRenderer>().sprite;
    }

    private void Update()
    {
        if (KeyM.keysCollected == KeyM.totalKeys)
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask collisionLayer = new LayerMask();
        collisionLayer.value = 1 << collision.gameObject.layer;

        if (playerLayer.Equals(collisionLayer) && KeyM.keysCollected == KeyM.totalKeys)
        {
            ScM.LoadNextScene();
        }
    }

    public void OpenDoor()
    {
        AM.DoorSound();
        GetComponent<SpriteRenderer>().sprite = openDoor;
        TB.StopTime();
    }

    public void ResetDoor()
    {
        GetComponent<SpriteRenderer>().sprite = closeDoor;
    }
}
