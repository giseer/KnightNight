using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehavior : MonoBehaviour
{
    public LayerMask playerLayer;   
    public UnityEvent OnCollect;

    private KeyManager KeyM;

    private void Start()
    {
        KeyM = transform.parent.GetComponent<KeyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask collisionLayer = new LayerMask();
        collisionLayer.value = 1 << collision.gameObject.layer;

        if (playerLayer.Equals(collisionLayer))
        {
            KeyM.GetComponent<AudioSource>().Play();
            KeyM.CollectKey();
            OnCollect.Invoke();
        }        
    }
}
