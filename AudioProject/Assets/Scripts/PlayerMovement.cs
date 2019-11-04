using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 _Movement;
    Quaternion _Rotation = Quaternion.identity;

    Animator _Animator;
    Rigidbody _RigidBody;

    AudioSource _FootStepsAudioSource;
    [SerializeField]
    AudioClip[] _FootStepsClips;

    public float turnSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _RigidBody = GetComponent<Rigidbody>();
        _FootStepsAudioSource = GetComponent<AudioSource>();
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

        if (isWalking)
        {
            PlayStep();
        }


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _Movement, turnSpeed * Time.deltaTime, 0f);
        _Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove()
    {
        _RigidBody.MovePosition(_RigidBody.position + _Movement * _Animator.deltaPosition.magnitude);
        _RigidBody.MoveRotation(_Rotation);
    }

    void PlayStep()
    {
        if (!_FootStepsAudioSource.isPlaying)
        {
            int clipIndex = Random.Range(0, _FootStepsClips.Length - 1);
            float pitch = Random.Range(1, 1.25f);
            _FootStepsAudioSource.pitch = pitch;
            _FootStepsAudioSource.PlayOneShot(_FootStepsClips[clipIndex], 0.75f);
        }
    }
}
