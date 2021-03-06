﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 90;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    void Start() {
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update() {
        if (controller.isGrounded) {
            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }
        } else {
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        }
        controller.Move(moveDirection * Time.deltaTime);
        Vector3 rotateCoords = new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        controller.transform.Rotate(rotateCoords);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Coin") {
            Destroy(hit.gameObject);
        }
    }
}
