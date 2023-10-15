using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 12f;
    CharacterController characterController;
    [SerializeField]
    float gravity = -9.81f;

    public Transform groundChecker;
    public LayerMask groundMask;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        CheckGroundType();
        characterController.Move(move * speed * Time.deltaTime);
        ApplyGravity();
    }

    void ApplyGravity()
    {
        characterController.Move(Vector3.up * gravity * Time.deltaTime);
    }

    void CheckGroundType()
    {
        RaycastHit hitResult;
        bool hit = Physics.Raycast(
            groundChecker.position,
            transform.TransformDirection(Vector3.down),
            out hitResult,
            0.4f,
            groundMask);

        if (hit)
        {
            string terrainType = hitResult.collider.gameObject.tag;
            switch(terrainType)
            {
                case "Slow":
                    speed = 3f;
                    break;
                case "Fast":
                    speed = 20f;
                    break;
                default:
                    speed = 12f;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
