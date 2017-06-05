using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	public float timeBetweenGrowers;
	float timePassed;

	MapGenerator mapGenerator;

	// Use this for initialization
	void Start()
	{
		mapGenerator = GetComponent<MapGenerator>();
	}

	// Update is called once per frame
	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > timeBetweenGrowers)
		{
			mapGenerator.spawnableTiles[Random.Range(0, mapGenerator.spawnableTiles.Count - 1)].gameObject.AddComponent<TileGrower>();
			timePassed = 0;
		}
	}
}