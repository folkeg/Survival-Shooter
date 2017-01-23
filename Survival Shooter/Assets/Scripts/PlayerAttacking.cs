using UnityEngine;
using System.Collections;

public class PlayerAttacking : MonoBehaviour {

	public float attackRate;
	public float effectTime;
	public float fireMaxDistance;
	public int damage;

	private int shootableMask;
	private float attackTime;
	private Ray fireRay;
	private RaycastHit fireHit;
	private ParticleSystem fireParticles;
	private Light fireLight;
	private LineRenderer fireLine;
	private AudioSource fireSound;

	void Awake(){
		shootableMask = LayerMask.GetMask ("Shootable");
		fireSound = GetComponent<AudioSource> ();
		fireParticles = GetComponent<ParticleSystem> ();
		fireLight = GetComponent<Light> ();
		fireLine = GetComponent<LineRenderer> ();
	}

	void Update(){
		attackTime += Time.deltaTime;
		if (Input.GetButton ("Fire1") && attackTime > attackRate) {
			Attack ();
		}
		if (attackTime > attackRate * effectTime) {
			DisableEffect ();
		}
	}

	void DisableEffect(){
		fireLight.enabled = false;
		fireLine.enabled = false;
	}

	void Attack(){
		attackTime = 0f;

		fireParticles.Stop ();
		fireParticles.Play ();

		fireSound.Play ();

		fireLight.enabled = true;

		fireLine.enabled = true;
		fireLine.SetPosition (0, transform.position);

		fireRay.origin = transform.position;
		fireRay.direction = transform.forward;

		if (Physics.Raycast (fireRay, out fireHit, fireMaxDistance, shootableMask)) {
			EnemyLife enemyLife = fireHit.collider.GetComponent<EnemyLife> ();
			if (enemyLife != null) {
				enemyLife.TakeDamage (damage, fireHit.point);
			} 
			fireLine.SetPosition (1, fireHit.point);
		} else {
			fireLine.SetPosition (1, fireRay.origin + fireRay.direction * fireMaxDistance);
		}

	}
}
