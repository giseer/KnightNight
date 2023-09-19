using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    public UnityEvent<int> OnChangeKeysCollected;

    public int totalKeys;

    [HideInInspector]
    public int keysCollected;

    private void Start()
    {
        keysCollected = 0;
    }

    public void CollectKey()
    {
        keysCollected++;
        OnChangeKeysCollected.Invoke(keysCollected);
    }

    public void ResetKeys()
    {
        keysCollected = 0;
        OnChangeKeysCollected.Invoke(keysCollected);

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
     
}
