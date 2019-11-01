using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 _Movement;
    Quaternion _Rotation = Quaternion.identity;

    Animator _Animator;
    Rigidbody _RigidBody;

    public float turnSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _Movement.Set(horizontal, 0f, vertical);
        _Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _Movement, turnSpeed * Time.deltaTime, 0f);
        _Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        _RigidBody.MovePosition(_RigidBody.position + _Movement * _Animator.deltaPosition.magnitude);
        _RigidBody.MoveRotation(_Rotation);
    }
}
