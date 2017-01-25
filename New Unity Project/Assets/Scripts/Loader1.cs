using UnityEngine;
using System.Collections;

public class Loader1 : MonoBehaviour {

	public GameObject gameManager;

	void Awake () {
		if (GameManager.instance == null)
			Instantiate (gameManager);
	}
}
