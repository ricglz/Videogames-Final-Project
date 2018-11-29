using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	int multiplier = 1;
	int streak = 0;
	int misses = 0;
	int hitNotes = 0;
	public static bool difficulty = true;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if(GameManager.difficulty){
			audioSource.pitch = 1.5f;
		}
		else{
			audioSource.pitch = 1;
		}

		Debug.Log(audioSource.pitch);
	}

	// Update is called once per frame
	void Update () {
		if(!audioSource.isPlaying){
			SceneManager.LoadScene(2);
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Destroy(col.gameObject);
		ResetStreak();
		misses ++;
	}
	
	public void AddStreak(){
		streak ++;
		hitNotes ++;
		if(streak >= 30){
			multiplier = 4;
		}
		else if(streak >= 15){
			multiplier = 3;
		}
		else if(streak >= 7){
			multiplier = 2;
		}
		else{
			multiplier = 1;
		}
		UpdateGUI();
	}

	public void ResetStreak(){
		streak = 0;
		multiplier = 1;
		UpdateGUI();
	}

	void UpdateGUI(){
		PlayerPrefs.SetInt("Streak", streak);
		PlayerPrefs.SetInt("Mult", multiplier);
	}

	public int GetScore(){
		return 100 * multiplier;
	}

	public bool GetDifficulty(){
		return difficulty;
	}
}
