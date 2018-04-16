using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
	protected float r;
	Vector3 movement;
	Vector3 rotation;
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
		Debug.Log("Horizontal:"+horizontal);
		Debug.Log("vertical:"+vertical);
		Turning(horizontal,vertical);
	}

	void Move(float h,float v){
		movement.Set(h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		//Debug.Log(movement);
		playerRigidbody.MovePosition(transform.position + movement);
		//playerRigidbody.position = new Vector3(playerRigidbody.position.x,0f,playerRigidbody.position.z);
	}

	void Turning(float h, float v){
		var angleH = ((h * 90F * Time.deltaTime) * 100f);
		var angleV = ((v * 90F * Time.deltaTime) * 100f);
		Debug.Log("Horizontal:"+h+"  Vertical"+v);
		r = (angleH + angleV / 2f);
		switch((int)h){
			case 1:
			  Debug.Log("DIREITA");	
              Rotation(v,r,90f);
              break;
			case -1:
			  Debug.Log("ESQUERDA");
              Rotation(v,r,-90f);
              break;
			case 0:
              Rotation(v,r,0f);
              break;    
		}
		
	}

	void Rotation(float v,float r, float limit=0f){
		switch((int)v){
			case 1:
			    Debug.Log("CIMA");
				if(limit == 0f){
					limit = 0f;
				}else{
					limit = limit / 2f;
				}
				break;
			case -1:
			    Debug.Log("BAIXO");
				if(limit == 0f){
					limit = 180f;
				}else{
					limit = (limit + (limit / 2));	
				}	
				break;
			case 0:
				limit = limit;
				break;	
		}
		if(playerRigidbody.rotation.eulerAngles.y < limit){
			rotation.Set(0f,r,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
        	playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}
	
	}
}
