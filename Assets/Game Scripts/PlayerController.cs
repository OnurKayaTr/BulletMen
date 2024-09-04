using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private Rigidbody rigidbody; 
    [SerializeField] private float moveSpeed;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private Transform playerChildTrnsfrm;
    private float horizontal;
    private float vertical;

    private void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }

    private void SetMovement() 
    {
        rigidbody.velocity = GetNewVelocity();
    }

    private void SetRotation()
    {
        if (horizontal != 0 || vertical != 0)  {

            playerChildTrnsfrm.rotation = Quaternion.LookRotation(GetNewVelocity());
        }
    }
    private Vector3 GetNewVelocity()
    {
        return new Vector3(horizontal, rigidbody.velocity.y, vertical) * moveSpeed * Time.fixedDeltaTime;
    }
    private void GetMovementInput()
    {
        horizontal = dynamicJoystick.Horizontal;
        vertical = dynamicJoystick.Vertical;
    }
}
