using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getHighScores : MonoBehaviour {

	// Use this for initialization
	public GameObject ladPower;
	public GameObject imiPower;
	public GameObject itcPower;
	public GameObject lmcPower;

	public GameObject finalB;

	void Start () {
		var ladP = PlayerPrefs.GetInt("");
		ladPower.GetComponent<Text>().text = ladP.ToString();

		var imiP = PlayerPrefs.GetInt("MusicScore");
		imiPower.GetComponent<Text>().text = imiP.ToString();

		var itcP = PlayerPrefs.GetInt("WordScore");
		itcPower.GetComponent<Text>().text = itcP.ToString();

		var lmcP = PlayerPrefs.GetInt("PuzzleScore");
		lmcPower.GetComponent<Text>().text = lmcP.ToString();


		if (PlayerPrefs.GetInt("") != 0 && PlayerPrefs.GetInt("MusicScore") != 0 && PlayerPrefs.GetInt("WordScore") != 0 && PlayerPrefs.GetInt("PuzzleScore") != 0) {
			finalB.GetComponent<Button>().interactable = true;
		} else {
			finalB.GetComponent<Button>().interactable = false;
		}
	}
}
