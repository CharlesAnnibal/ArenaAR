using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
	Vector3 movement;
	Rigidbody playerRigidbody;
	// Use this for initialization
	void Awake(){
		playerRigidbody = GetComponent <Rigidbody>();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical  = Input.GetAxisRaw("Vertical");
		Move(horizontal,vertical);
	}

	void Move(float h,float v){
		movement.Set(h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning(){

	}
}
