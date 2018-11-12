using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Destroy(col.gameObject);
		ResetStreak();
		misses ++;
		if(misses >= 10){
			Debug.Log("QUIT");
			Application.Quit();
		}
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

		if(hitNotes + misses >= 103){
			Debug.Log("QUIT");
			Application.Quit();
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
