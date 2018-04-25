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
		Turning(horizontal,vertical);
	}

	void Move(float h,float v){
		movement.Set(h,0f,v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
		//playerRigidbody.position = new Vector3(playerRigidbody.position.x,0f,playerRigidbody.position.z);
	}

	void Turning(float h, float v){
		var angleH = ((h * 90F * Time.deltaTime) * 100f);
		var angleV = ((v * 90F * Time.deltaTime) * 100f);
		
		r = (angleH + angleV / 2f);

		switch((int)h){
			case 1:
              Rotation("DIREITA",v,r);
              break;
			case -1:
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
					Rotating(r,limit,oposite);
				}else if(h=="ESQUERDA"){
					limit = -45f;
					oposite = 135f;
					Rotating(r,limit,oposite);
				}else{
					limit = 0f;
					oposite = 180f;
					Rotating(r,limit,oposite);
				}
				break;
			case -1:
			    if(h=="DIREITA"){
					limit = 135f;
					oposite = -45f;
					Rotating(r,limit,oposite);
				}else if(h=="ESQUERDA"){
					limit = -135f;
					oposite = 45f;
					Rotating(r,limit,oposite);
				}else{
					limit = 180f;
					oposite = 0f;
					Rotating(r,limit,oposite);
				}	
				break;
			case 0:
				r = r /2f;
				if(h=="DIREITA"){
					limit = 90f;
					oposite = -90f;
					Rotating(r,limit,oposite);
				}else if(h=="ESQUERDA"){
					limit = -90f;
					oposite = 90f;
					Rotating(r,limit,oposite);
				}
				break;	
		}
		
		/*var playerAngle = playerRigidbody.rotation.eulerAngles.y;

		if(playerRigidbody.rotation.eulerAngles.y > 180f){
			playerAngle = playerRigidbody.rotation.eulerAngles.y -360f;
		}


		if(playerAngle < limit){
			rotation.Set(0f,r,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
        	playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}else{
			r = 0f - r;
			rotation.Set(0f,r,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
        	playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}*/
	
	}

	void Rotating(float r,float direcao,float oposite){
		var rotate = r;
		var playerAngle = playerRigidbody.rotation.eulerAngles.y;
		if(playerAngle > 180f){
			playerAngle = playerAngle - 360f;
		}
		if(playerAngle < 0f){//ENTRE -179 ATÉ 0

			
			if(playerAngle < direcao && direcao < 0f){//(direcao 45- OPOSTO-135)  (direcao 90 OPOSTO -90)
				rotate = 200f;
				Debug.Log("1) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
				
			}else if (playerAngle < direcao && direcao > 0f && playerAngle < oposite){
				rotate = -200f;
				Debug.Log("2) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}else if(playerAngle < direcao && direcao > 0f && playerAngle > oposite){
				rotate = 200f;
				Debug.Log("3) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}
			
			else if(playerAngle > direcao && playerAngle < oposite){//(direcao -45 OPOSTO 135)  (direcao -90 OPOSTO 90) (0 - 180)
				rotate = -200f;
				Debug.Log("4) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}
			rotation.Set(0f,rotate,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
			playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);

		}else{
			Debug.Log(playerAngle+"  "+direcao);
			if(playerAngle > direcao && direcao >= 0f){//(direcao -45 OPOSTO 135)  (direcao -90 OPOSTO 90) (0 - 180)
				rotate = -200f;
				Debug.Log("5) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}else if(playerAngle > direcao && (direcao < 0f && playerAngle < oposite)){
				rotate = -200f;
				Debug.Log("6) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}else if(playerAngle > direcao && (direcao < 0f && playerAngle > oposite)){
				rotate = 200f;
				Debug.Log("7) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}
			
			/*else if(playerAngle < direcao && direcao < 0f){
				rotate = 90f;
				Debug.Log("8) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}*/
			else if(playerAngle < direcao && direcao > 0f){
				rotate = 200f;
				Debug.Log("8) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}

			rotation.Set(0f,rotate,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
			playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}
		
		
	}
}
