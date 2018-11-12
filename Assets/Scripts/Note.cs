using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	Rigidbody2D rb;
	public float speed;
	GameObject gm;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Start () {
		if(GameManager.difficulty){
			speed = 5*1.5F;
		}
		else{
			speed = 5;
		}
		rb.velocity=new Vector2(0,-speed);
	}
}
