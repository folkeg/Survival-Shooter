using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	public int health;
	public float sinkSpeed;
	public AudioClip deathClip;
	public int enemyScore;

	private ParticleSystem hitParticles;
	private bool isDead;
	private bool isSinking;
	private AudioSource enemySound;
	private Animator anim;

	void Awake(){
		hitParticles = GetComponentInChildren<ParticleSystem> ();
		anim = GetComponent<Animator> ();
		enemySound = GetComponent<AudioSource> ();
	}

	void FixedUpdate(){
		if (isSinking) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage(int damage, Vector3 hitPoint){
		health -= damage;
		enemySound.Play ();
		hitParticles.transform.position = hitPoint;
		hitParticles.Play ();
		if (health <= 0 && !isDead) {
			EnemyDeath ();
		}
	}

	void EnemyDeath(){
		ScoreController.score += enemyScore;
		isDead = true;
		enemySound.clip = deathClip;
		enemySound.Play ();
		anim.SetTrigger ("EnemyDie");
	}

	public void StartSinking(){
		isSinking = true;
		GetComponent<EnemyMove> ().enabled = false;
		GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Destroy (gameObject, 2f);
	}
}
