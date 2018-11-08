using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 2.0f;
    /*public float jump = 3.0f;
    public float gravity = 10.0f;*/
    private CharacterController cc;

    private void Start() {
        cc = GetComponent<CharacterController>();
    }

    private void Update() {
        Vector3 move = Vector3.zero;
        /*if(Input.GetButton("Horizontal")) {
            move.z = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        }
        if(Input.GetButton("Jump")) {
            move.y = jump * Time.deltaTime;
        }
        move.y -= gravity * Time.deltaTime;*/
        move.x = speed * Time.deltaTime;
        cc.Move(move);
    }

}
