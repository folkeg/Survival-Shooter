using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

	public Slider healthSlider;
	public Image damageImage;
	public float flashTime;
	public int health;
	public AudioClip deathClip;

	private Color flashColor;
	private Animator anim;
	private bool isDead;
	private bool isDamaged;
	private AudioSource playerSound;

	void Awake(){
		flashColor = new Color (1.0f, 0.0f, 0.0f, 0.1f);
		anim = GetComponent<Animator> ();
		playerSound = GetComponent<AudioSource> ();
	}

	void FixedUpdate(){
		if (isDamaged) {
			damageImage.color = flashColor;
			isDamaged = false;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashTime * Time.deltaTime);
		}
	}

	public void TakeDamage(int damage){
		isDamaged = true;
		health -= damage;
		healthSlider.value = health;
		playerSound.Play ();
		if (health <= 0 && !isDead) {
			Death ();
		}
	}

	void Death(){
		isDead = true;
		playerSound.clip = deathClip;
		playerSound.Play ();
		GetComponent<PlayerMovement> ().enabled = false;
		anim.SetTrigger ("Die");
	}

	public void RestartLevel(){
		SceneManager.LoadScene (1);
	}
}
