using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knightctrl : MonoBehaviour
{
	public float speed = 15;
	public float rotSpeed = 100;
	public float rot = 0f;
	public float gravity = 8;


	Vector3 moveDir = Vector3.zero;


	CharacterController controller;
	Animator anim;


	void Start()
	{


		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}



	void Update()
	{
		Movement();
		GetInput();


	}
	void Movement()
	{
		if (controller.isGrounded)
		{


			if (Input.GetKey(KeyCode.W))
			{
				if (anim.GetBool("attacking") == true)
				{
					return;
				}
				else if (anim.GetBool("attacking") == false)
				{
					anim.SetInteger("running", 1);
					anim.SetInteger("condition", 1);
					moveDir = new Vector3(0, 0, 1);
					moveDir *= speed;
					moveDir = transform.TransformDirection(moveDir);
				}
			}
			if (Input.GetKeyUp(KeyCode.W))
			{
				anim.SetInteger("running", 0);
				anim.SetInteger("condition", 0);
				moveDir = new Vector3(0, 0, 0);


			}
		}
		rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		transform.eulerAngles = new Vector3(0, rot, 0);


		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}

	void GetInput()
	{
		if (controller.isGrounded)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (anim.GetBool("running") == true)
				{
					anim.SetInteger("running", 0);
					anim.SetInteger("condition", 0);
				}
				if (anim.GetInteger("running") == 0)
				{
					Attacking();
				}
			}
		}
	}

	void Attacking()

	{
		StartCoroutine(AttackRoutine());
	}
	IEnumerator AttackRoutine()
	{
		anim.SetBool("attacking", true);
		anim.SetInteger("condition", 2);
		yield return new WaitForSeconds(1);
		anim.SetInteger("condition", 0);
		anim.SetBool("attacking", false);
	}
}