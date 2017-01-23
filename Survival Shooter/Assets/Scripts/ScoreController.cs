using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static int score;

	private Text scoreText;

	void Awake(){
		scoreText = GetComponent<Text> ();
	}

	void Update(){
		scoreText.text = "Score : " + score;
	}
}
