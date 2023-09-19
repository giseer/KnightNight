using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysTextUpdater : MonoBehaviour
{
    public void SetKeysText(int keys)
    {
        GetComponent<TMP_Text>().text = "Keys: " + keys;
    }
}
