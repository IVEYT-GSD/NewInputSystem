using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 0.1f;
	public float bulletSpeed = 10.0f;	
	public float rotateSpeed = 0.1f;

	
	//public InputAction playerControls;
	public InputAction move;
	public InputAction fire;
	public PlayerInputActions playerControls;
	public GameObject bulletPrefab;	
	
	Vector2 moveDirection = Vector2.zero;

	private void Awake()
	{
		playerControls = new PlayerInputActions();
	}

	private void OnEnable()
	{
		//playerControls.Enable();
		move = playerControls.Player.Move;
		move.Enable();

		fire = playerControls.Player.Fire;
		fire.Enable();
		fire.performed += Fire;

	}

	private void OnDisable() 
	{
		//playerControls.Disable();
		move.Disable();
		fire.Disable();
	}

	// Update is called once per frame
	void Update()
	{
		//moveDirection = playerControls.ReadValue<Vector2>();		
		moveDirection = move.ReadValue<Vector2>();


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

	private void Fire(InputAction.CallbackContext context)
    {
		Debug.Log("We fired..." + transform.Find("WeaponHolder").transform.position);

		//Instantiate(bulletPrefab, new Vector3(0, 0, 3), Quaternion.identity);
		//GameObject bullet = Instantiate(bulletPrefab, new Vector3(0, 0, 3), Quaternion.identity);
		GameObject bullet = Instantiate(bulletPrefab, transform.Find("WeaponHolder").transform.position, Quaternion.identity);

		bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
		



	}

}
