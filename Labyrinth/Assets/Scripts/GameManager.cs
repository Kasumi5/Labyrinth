﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private boardManager boardScript; 
	private int level = 3;

	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent <boardManager> ();
		InitGame ();
	}

	void InitGame () {
		boardScript.SetupScene (level);
	}
}
