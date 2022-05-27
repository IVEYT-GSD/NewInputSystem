using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
	public float moveSpeed = 0.1f;
	public float rotateSpeed = 0.1f;

	public Rigidbody rb;	
	public InputAction playerControls;
	Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
		playerControls.Enable();
    }

	private void OnDisable()
	{
		playerControls.Disable();
	}

	// Update is called once per frame
	void Update() 
	{
		moveDirection = playerControls.ReadValue<Vector2>();		

		/*
			if (Input.GetKey("up"))
				transform.Translate(Vector3.forward * moveSpeed);
			if (Input.GetKey("down"))
				transform.Translate(Vector3.forward * -moveSpeed);
			if (Input.GetKey("left"))
				transform.Rotate(Vector3.up * -rotateSpeed);
			if (Input.GetKey("right"))
				transform.Rotate(Vector3.up * rotateSpeed);
		*/
	}
	
    private void FixedUpdate()
    {
		Debug.Log(moveDirection);		
		transform.Translate(0, 0, moveDirection.y * moveSpeed);
		transform.Rotate(Vector3.up * moveDirection.x * rotateSpeed);
	}
	

}
