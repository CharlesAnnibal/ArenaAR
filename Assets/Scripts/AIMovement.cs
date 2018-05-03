using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	// Use this for initialization

	void Awake(){
		player 	= GameObject.FindGameObjectWithTag("Player1").transform;
		nav 	= GetComponent <NavMeshAgent>(); 
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.position);
	}
}
