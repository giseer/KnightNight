using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int enemyType;
    public GameObject minPos;
    public GameObject maxPos;
    public GameObject gem;
    public LayerMask playerLayer;

    private MovementBehavior mb;
    private SpriteRenderer rc;

    private Vector3 dir;
    private Vector3 dirPos;

    private void Start()
    {
        mb = GetComponent<MovementBehavior>();
        rc = GetComponent<SpriteRenderer>();
        dirPos = maxPos.transform.position;
    }

   // transform.position;

    void Update()
    {
        if((transform.position.x).ToString("F1") == (maxPos.transform.position.x - 0.1f).ToString("F1"))
        {
            dirPos = minPos.transform.position;
            rc.flipX = true;
        }
        else if((transform.position.x).ToString("F1") == (minPos.transform.position.x + 0.1f).ToString("F1"))
        {
            dirPos = maxPos.transform.position;
            rc.flipX = false;
        }

        //Debug.Log(transform.position.x);
        //Debug.Log(dirPos);


        dir = dirPos - transform.position;
        dir.Normalize();
        mb.Move(dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask collisionLayer = new LayerMask();
        collisionLayer.value = 1 << collision.gameObject.layer;

        if (playerLayer.Equals(collisionLayer))
        {
            if (enemyType == 2)
            {
                gem.SetActive(true);
            }
        }
    }

}
