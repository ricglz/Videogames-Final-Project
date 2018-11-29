using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

	SpriteRenderer sr;
	public KeyCode key;
	bool active = false;
	GameObject note, gm;
	Color old;
	
	
	void Awake(){
		sr = GetComponent<SpriteRenderer>();
	}

	void Start(){
		old = sr.color;
		gm = GameObject.Find("GameManager");
		PlayerPrefs.SetInt("MusicScore", 0);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)){
			sr.color = new Color(0.2169811f,0.2169811f,0.2169811f);
		}
		if(Input.GetKeyUp(key)){
			sr.color = old;
		}
		if(Input.GetKeyDown(key) && active){
			Destroy(note);
			gm.GetComponent<GameManager>().AddStreak();
			AddScore();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		active = true;
		if(col.gameObject.CompareTag("note")){
			note = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		active = false;
	}

	void AddScore(){
		PlayerPrefs.SetInt("MusicScore", PlayerPrefs.GetInt("MusicScore") + gm.GetComponent<GameManager>().GetScore());
	}
}
