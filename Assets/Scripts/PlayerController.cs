using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool grounded;
    public LayerMask groundLayer;
    public float jumpSpeed;

    private MovementBehavior _mvb;
    private NewControls nc;
    private Vector3 initialPosition;

    void Start()
    {
        _mvb = GetComponent<MovementBehavior>();
        nc = GetComponent<NewControls>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if(nc.jumpPressed && grounded)
        {
            _mvb.Jump(jumpSpeed);
            nc.jumpPressed = false;            
        }

        _mvb.MoveRB(nc.moveValue.x * transform.right);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);
        if (hit)
            grounded = true;
        else
            grounded = false;
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition;
    }
}
