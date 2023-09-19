using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewControls : MonoBehaviour
{

    public Vector2 moveValue;
    public bool jumpPressed;

    private Animator playerAnim;
    private SpriteRenderer sp;
    private InputPlayerActions ipa;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        ipa = new InputPlayerActions();
        ipa.Player.Move.performed += OnMove;
        ipa.Player.Jump.performed += OnJump;
        ipa.Player.Jump.canceled += OnStopJump;
        ipa.Player.Move.canceled += OnStopMove;
    }

    private void OnMove(InputAction.CallbackContext c)
    {
        moveValue = c.ReadValue<Vector2>();
        playerAnim.SetInteger("state", 1);

        Vector2 inputVector2 = c.ReadValue<Vector2>();
        float moveX = inputVector2.x;

        if(moveX < 0)
        {
            sp.flipX = true;
        }
        else if (moveX > 0)
        {
            sp.flipX = false;
        }
    }

    private void OnJump(InputAction.CallbackContext c)
    {
        jumpPressed = true;
        playerAnim.SetInteger("state", 2);
    }

    private void OnStopMove(InputAction.CallbackContext c)
    {
        moveValue = Vector2.zero;
        playerAnim.SetInteger("state", 0);
    }

    private void OnStopJump(InputAction.CallbackContext c)
    {
        moveValue.y = 0;
        playerAnim.SetInteger("state", 0);
    }

    //Animaciones temporal
    public void DieAnimation()
    {
        playerAnim.SetInteger("state", 5);
    }

    public void HurtAnimation()
    {
        playerAnim.SetInteger("state", 4);
    }

    public void ResetAnimation()
    {
        playerAnim.SetInteger("state", 0);
    }

    public void StartControls()
    {
        GetComponent<NewControls>().enabled = true;
    }

    public void StopControls()
    {
        GetComponent<NewControls>().enabled= false;
    }

    private void OnEnable()
    {
        ipa.Enable();
    }

    private void OnDisable()
    {
        ipa.Disable();
    }
}
