using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 4.0f;
    public GameObject cam;

    private CharacterController _charCont;
    private AudioSource asource; //

    public AudioClip c1;
    public AudioClip c2;

    // Use this for initialization
    void Start() {
        _charCont = GetComponent<CharacterController>();
        asource = GetComponent<AudioSource>(); //
    }

    // Update is called once per frame
    void Update() {

        Vector3 lookDir = cam.transform.forward;
        lookDir.y = 0;
        Quaternion rotationOfMoveDirection = Quaternion.LookRotation(lookDir, Vector3.up);
        transform.rotation = rotationOfMoveDirection;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //Limits the max speed of the player

        movement *= Time.deltaTime;     //Ensures the speed the player moves does not change based on frame rate
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);
    }

    private void OnTriggerEnter(Collider other) { //
        if(other.gameObject.tag == "Coin") {
            asource.clip = c1;
            asource.Play();
            Destroy(other.gameObject);
        }
    }
}
