using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    //�Ʒ� ���� ����
    //https://www.youtube.com/watch?v=Xf2eDfLxcB8
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private LayerMask groudLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private void Update()
    {
        bool _isGrounded = IsGrounded();

        if (jumpButton.action.WasPerformedThisFrame() && _isGrounded)
        {
            Jump();
        }

        movement.y += gravity * Time.deltaTime;

        //CharacterControllerDriver�м��ؼ� �ϱ�...
        //characterController.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groudLayers);
    }
}
