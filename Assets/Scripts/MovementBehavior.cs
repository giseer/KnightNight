using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D _rb;

    private void Awake()
    {
        
    }

    private void Start()
    {
        if (!TryGetComponent<Rigidbody2D>(out _rb))
            _rb = null;
    }
    public void Move(Vector3 dir)
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void Move(Vector3 dir, float speed)
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void MoveForward(float speed)
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void MoveForward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void MoveRB(Vector3 dir, float speed)
    {
        if (_rb)
            _rb.velocity = dir * speed;
    }

    public void MoveRB(Vector3 dir)
    {
        if (_rb)
        {
            _rb.velocity = new Vector3(dir.x * speed, _rb.velocity.y, dir.z * speed);

        }

    }

    public void StopMovement()
    {
        if(_rb)
        {
            //_rb = Vector3.Zero;
        }
    }

    public void Jump(float jumpSpeed)
    {
        if(_rb)
        {
            _rb.AddForce(new Vector2(0, jumpSpeed));
        }
    }
}
