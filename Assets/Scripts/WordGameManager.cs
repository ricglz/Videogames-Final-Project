using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordGameManager : MonoBehaviour {

	public Text txtScore;
	public Text txtTime;
	public static int score = 0;
	float time = 60f;
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		txtScore.text = "Score: " + score;
		txtTime.text = "Time left: " + System.Math.Round(time, 2);
	}
}
