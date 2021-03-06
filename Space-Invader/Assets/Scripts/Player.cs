﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary 
{
	public float xMin,xMax;
}

public class Player : MonoBehaviour {

	public float speed;
	public Boundary boundary;

	public GameObject laser;
	public Transform shotSpawn;

	private Rigidbody2D rb;
	private bool canFire = true;


	private Animator animator;
	
		
	void Start() {
		animator = GetComponent<Animator> ();	
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical); 
		rb.velocity = movement * speed;
		rb.position = new Vector3 
			(	Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
				0,
				0);
	}
	
	void Update() {
		animator.SetBool("run",rb.velocity.x !=0);
		if (Input.GetButton("Fire1") && canFire ){
			canFire = false;
			Instantiate(laser,shotSpawn.position,shotSpawn.rotation);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ennemy") {
			Destroy(other.gameObject);
			GameManager.instance.PlayerLooseLive();
			ReinitPosition ();
		}
	}

	public void CanFireAgain (){
		canFire = true;
	}

	private void ReinitPosition (){
		rb.velocity = Vector3.zero;
	}
}
