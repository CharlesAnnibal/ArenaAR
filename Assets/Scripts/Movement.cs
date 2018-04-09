using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//this.GetComponent<Rigidbody>().AddForce(Vector3.down * 20000f * this.GetComponent<Rigidbody>().mass);
		/*float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

		

		if (Input.GetButtonDown("Horizontal")){
			float translation = Input.GetAxis("Horizontal") * speed;
			this.transform.position =  new Vector3(this.transform.position.x - 1000f,this.transform.position.y,this.transform.position.z);
		}

		if (Input.GetButtonDown("Vertical")){
			float translation = Input.GetAxis("Vertical") * speed;
			this.transform.position =  new Vector3(this.transform.position.x - 1000f,this.transform.position.y,this.transform.position.z);
		}*/

	}
}
