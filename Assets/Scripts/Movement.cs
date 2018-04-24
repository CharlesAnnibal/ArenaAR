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
		
		r = (angleH + angleV / 2f);
		Debug.Log("Horizontal:"+h+"  Vertical"+v+"  r="+r);
		switch((int)h){
			case 1:
			  Debug.Log("DIREITA");	
              Rotation("DIREITA",v,r);
              break;
			case -1:
			  Debug.Log("ESQUERDA");
              Rotation("ESQUERDA",v,r);
              break;
			case 0:
              Rotation("NEUTRO",v,r);
              break;    
		}
		
	}

	void Rotation(string h,float v,float r){
		var limit = 0f;
		var oposite = 0f;
		switch((int)v){
			case 1:
			    if(h=="DIREITA"){
					limit = 45f;
					oposite = -135f;
				}else if(h=="ESQUERDA"){
					limit = -45f;
					oposite = 135f;
				}else{
					limit = 0f;
					oposite = 180f;
				}
				break;
			case -1:
			    if(h=="DIREITA"){
					limit = 135f;
					oposite = -45f;
				}else if(h=="ESQUERDA"){
					limit = -135f;
					oposite = 45f;
				}else{
					limit = 180f;
					oposite = 0f;
				}	
				break;
			case 0:
				if(h=="DIREITA"){
					limit = 90f;
				}else if(h=="ESQUERDA"){
					limit = -90f;
				}
				break;	
		}
		
		var playerAngle = playerRigidbody.rotation.eulerAngles.y;

		if(playerRigidbody.rotation.eulerAngles.y > 180f){
			playerAngle = playerRigidbody.rotation.eulerAngles.y -360f;
		}
		Debug.Log("Angulo P1="+playerAngle+" LIMIT="+limit);

		if(playerAngle < limit){
			rotation.Set(0f,r,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
        	playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}else{
			r = 0f - r;
			rotation.Set(0f,r,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
        	playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}
	
	}

	void Rotating(float r,float limit,float oposite){
		var rotate = r;
		var playerAngle = playerRigidbody.rotation.eulerAngles.y;
		if(playerAngle < 0f){//ENTRE -179 ATÉ 0

			
			if(playerAngle < limit && playerAngle > oposite){//(LIMIT 45- OPOSTO-135)  (LIMIT 90 OPOSTO -90)
				rotate = rotate;
			}else if(playerAngle > limit && playerAngle < oposite){//(LIMIT -45 OPOSTO 135)  (LIMIT -90 OPOSTO 90) (0 - 180)
				rotate = 0f - rotate;
			}
			rotation.Set(0f,rotate,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
			playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);

		}else{
			if(playerAngle > limit && playerAngle < oposite){//(LIMIT -45 OPOSTO 135)  (LIMIT -90 OPOSTO 90) (0 - 180)
				rotate = 0f - rotate;
			}else if(playerAngle < limit){
				rotate = rotate;
			}

			rotation.Set(0f,rotate,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
			playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}
		
		
	}
}
