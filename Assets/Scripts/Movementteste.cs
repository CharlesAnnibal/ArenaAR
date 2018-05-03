using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementteste : MonoBehaviour {

	public float speed;
	protected float r;
	Vector3 movement;
	Vector3 rotation;
	float rotationLeft = -450f;
	float rotationRight = 450f;
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
		MovementStart(horizontal,vertical);
	}

	void MovementStart(float hor,float v){
		var angleH = ((hor * 90F * Time.deltaTime) * 100f);
		var angleV = ((v * 90F * Time.deltaTime) * 100f);
		var h = "";
		r = (angleH + angleV / 2f);

		switch((int)hor){
			case 1:
              h = "DIREITA";
              break;
			case -1:
              h = "ESQUERDA";
              break;
			case 0:
              h = "NEUTRO";
              break;    
		}

		var oposite = 0f;
		var direction = 0f;
		switch((int)v){
			case 1:
			    if(h=="DIREITA"){
					direction = 45f;
					oposite = -135f;
				}else if(h=="ESQUERDA"){
					direction = -45f;
					oposite = 135f;
				}else{
					direction = 0f;
					oposite = -180f;
				}
				break;
			case -1:
			    if(h=="DIREITA"){
					direction 	= 135f;
					oposite 	= -45f;
				}else if(h=="ESQUERDA"){
					direction 	= -135f;
					oposite 	= 45f;
				}else{
					direction 	= 180;
					oposite 	= 0f;
				}	
				break;
			case 0:
				r = r /2f;
				if(h=="DIREITA"){
					direction 	= 90f;
					oposite 	= -90f;
				}else if(h=="ESQUERDA"){
					direction 	= -90f;
					oposite 	= 90f;
				}
				break;	
		}
		Rotating(r,direction,oposite);
		Move(hor,v,direction);
	}

	void Move(float h,float v,float direcao){
		var playerAngle = playerRigidbody.rotation.eulerAngles.y;
		if(playerAngle < direcao + 5f && playerAngle > direcao -5f){
			movement.Set(h,0f,v);
			movement = movement.normalized * speed * Time.deltaTime;
			playerRigidbody.MovePosition(transform.position + movement);
		}
	}

	void Rotating(float r,float direcao,float oposite){
		var rotate = r;
		var playerAngle = playerRigidbody.rotation.eulerAngles.y;
		if(playerAngle > 180f){
			playerAngle = playerAngle - 360f;
		}
		if(playerAngle < 0f){//ENTRE -179° ATÉ 0

			
			if(playerAngle < direcao && direcao < 0f){//(direcao 45- OPOSTO-135)  (direcao 90 OPOSTO -90)
				rotate = rotationRight;
				Debug.Log("1) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
				
			}else if (playerAngle < direcao && direcao > 0f && playerAngle < oposite){
				rotate = rotationLeft;
				Debug.Log("2) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}else if(playerAngle < direcao && direcao > 0f && playerAngle > oposite){
				rotate = rotationRight;
				Debug.Log("3) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}
			
			else if(playerAngle > direcao && playerAngle < oposite){//(direcao -45 OPOSTO 135)  (direcao -90 OPOSTO 90) (0 - 180)
				rotate = rotationLeft;
				Debug.Log("4) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}
			rotation.Set(0f,rotate,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
			playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);

		}else{ //ENTRE 0 E 180°
			Debug.Log(playerAngle+"  "+direcao);
			if(playerAngle > direcao && direcao >= 0f){//(direcao -45 OPOSTO 135)  (direcao -90 OPOSTO 90) (0 - 180)
				rotate = rotationLeft;
				Debug.Log("5) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}else if(playerAngle > direcao && (direcao < 0f && playerAngle < oposite)){
				rotate = rotationLeft;
				Debug.Log("6) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}else if(playerAngle > direcao && (direcao < 0f && playerAngle > oposite)){
				rotate = rotationRight;
				Debug.Log("7) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}
			
			/*else if(playerAngle < direcao && direcao < 0f){
				rotate = 90f;
				Debug.Log("8) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}*/
			else if(playerAngle < direcao && direcao > 0f){
				rotate = rotationRight;
				Debug.Log("8) - P angle = "+playerAngle+"  direcao="+direcao+"   oposite="+oposite+"  rotation="+rotate);
			}

			rotation.Set(0f,rotate,0f);
			Quaternion deltaRotation = Quaternion.Euler(rotation  * Time.deltaTime);
			playerRigidbody.MoveRotation(playerRigidbody.rotation * deltaRotation);
		}
		
		
	}
}
