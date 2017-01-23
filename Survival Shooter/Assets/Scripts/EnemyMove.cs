using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	private Transform playerTransform;
	private UnityEngine.AI.NavMeshAgent navMashAgent;

	void Awake(){
		playerTransform = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();;
		navMashAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Update(){
		
		navMashAgent.destination = playerTransform.position;
	}


}
