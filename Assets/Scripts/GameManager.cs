using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	int multiplier = 1;
	int streak = 0;
	int misses = 0;
	int hitNotes = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

		if(hitNotes + misses == 103){
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
}
