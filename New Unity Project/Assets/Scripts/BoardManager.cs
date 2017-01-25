using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;
	public GameObject[] wallTilesH;
	public GameObject[] wallTilesV;
	public GameObject[] floorTiles;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();


	public class Count
	{
		public int minimum;
		public int maximum;

		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	void InitialiseList ()
	{
		gridPositions.Clear ();
		for (int x = 1; x < columns - 1; x++) {
			for (int y = 1; y < rows - 1; y++) {
				gridPoistions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void BoardSetup ()
	{
		boardHolder = new GameObject ("Board").transform;
		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				if (x == -1 || x == columns)
					toInstantiate = wallTilesV [Random.Range (0, wallTilesV.Length)];
				if (y == -1 || y == rows)
					toInstantiate = wallTilesH [Random.Range (0, wallTilesH.Length)];
				instance.transform.SetParent (boardHolder);
			}
		}
	}

	public void SetupScene (int level)
	{
		BoardSetup ();
		Initialise List ();
	}	
}
