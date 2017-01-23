using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float spawnTime;
	public GameObject enemy;
	public PlayerLife playerLife;
	public Transform[] spawnValue;

	void Start(){
		InvokeRepeating ("SpawnEnemy", spawnTime, spawnTime);
	}

	void SpawnEnemy(){
		if (playerLife.health <= 0) {
			return;
		}
		int index = Random.Range (0, spawnValue.Length);
		Instantiate (enemy, spawnValue [index].position, spawnValue [index].rotation);
	}
}
