using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

	public GameObject wordPrefab;
	public Transform wordCanvas;
	public float minX;
	public float maxX;
	public float Y;

	public WordDisplay SpawnWord ()
	{
		Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Y);

		GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

		return wordDisplay;
	}

}
