using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
		if(time <= 0) {
			int currentMaxScore = PlayerPrefs.GetInt("WordScore");
			if(score > currentMaxScore) {
				PlayerPrefs.SetInt("WordScore", score);
			}
			SceneManager.LoadScene("Menu 3D");
		}
	}
}
