using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class boardManager : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;
	public GameObject BR;
	public GameObject BL;
	public GameObject TR;
	public GameObject TL;
	public GameObject [] wallTilesH;
	public GameObject [] wallTilesV;
	public GameObject [] floorTiles;

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
		gridPositions.Clear();
		for(int x = 1; x < columns - 1; x++)
		{for (int y = 1; y < rows - 1; y++)
			gridPositions.Add (new Vector3 (x, y, 0f));
		}
	}

	void BoardSetup ()
	{
		boardHolder = new GameObject ("Board").transform;
		GameObject CornerBR =
			Instantiate (BR, new Vector3 (7, 0, 0f), Quaternion.identity) as GameObject;
		GameObject CornerBL =
			Instantiate (BL, new Vector3 (0, 0, 0f), Quaternion.identity) as GameObject;
		GameObject CornerTR =
			Instantiate (TR, new Vector3 (7, 7, 0f), Quaternion.identity) as GameObject;
		GameObject CornerTL =
			Instantiate (TL, new Vector3 (0, 7, 0f), Quaternion.identity) as GameObject;
		for (int x = -0; x < columns; x++) {
			for (int y = -0; y < rows; y++) {
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				if (x == -0 || x == columns-1)
					toInstantiate = wallTilesV [Random.Range (0, wallTilesV.Length)];
				if (y == -0 || y == rows-1)
					toInstantiate = wallTilesH [Random.Range (0, wallTilesH.Length)];
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}
	}

	public void SetupScene (int level)
	{
		BoardSetup ();
		InitialiseList ();
	}	
}
	

