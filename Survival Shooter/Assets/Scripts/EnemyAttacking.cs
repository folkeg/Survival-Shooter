using UnityEngine;
using System.Collections;

public class EnemyAttacking : MonoBehaviour {

	public float attackRate;
	public int damage;

	private float attackTime;
	private Animator anim;
	private PlayerLife playerLife;
	private bool playerInRange;

	void Awake(){
		anim = GetComponent<Animator> ();
		playerLife = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerLife> ();
	}

	void FixedUpdate(){
		attackTime += Time.deltaTime;
		if (attackTime > attackRate && playerInRange && playerLife.health > 0) {
			Attack ();
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerInRange = false;
		}
	}

	void Attack(){
		attackTime = 0f;
		playerLife.TakeDamage (damage);
		if (playerLife.health <= 0f) {
			anim.SetTrigger ("PlayerDie");
		}
	}
}
