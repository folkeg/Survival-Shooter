using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public PlayerLife playerLife;

	private Animator anim;

	void Awake(){
		anim = GetComponent<Animator> ();
	}

	void Update(){
		if (playerLife.health <= 0) {
			anim.SetTrigger ("GameOver");
		}
	}
}
