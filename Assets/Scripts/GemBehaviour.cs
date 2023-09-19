using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    public DoorBehavior DB;
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask collisionLayer = new LayerMask();
        collisionLayer.value = 1 << collision.gameObject.layer;

        if (playerLayer.Equals(collisionLayer))
        {
            DB.OpenDoor();
            Destroy(gameObject);
        }
    }
}
