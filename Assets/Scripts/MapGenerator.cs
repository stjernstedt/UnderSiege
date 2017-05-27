using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public int width;
	public int height;
	public GameObject tilePrefab;
	public GameObject basePrefab;
	public int safezoneRange;

	public static Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();
	public List<Tile> spawnableTiles = new List<Tile>();

	public Transform tilesParent;

	// Use this for initialization
	void Start()
	{
		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < height; z++)
			{
				GameObject tileObj = Instantiate(tilePrefab);
				tileObj.transform.position = new Vector3(x, 0, z);
				Color color = new Color(Random.Range(0f, 0.2f), Random.Range(0.8f, 1f), Random.Range(0f, 0.2f));
				tileObj.GetComponent<MeshRenderer>().material.color = color;
				tileObj.transform.SetParent(tilesParent);
				Tile tile = tileObj.GetComponent<Tile>();
				tile.Init();
				tiles.Add(new Vector2(x, z), tile);
				tile.tileKey = new Vector2(x, z);
			}
		}

		foreach (KeyValuePair<Vector2, Tile> tile in tiles)
		{
			tile.Value.CalculateNeighbours();
		}

		Vector2 center = new Vector2(width / 2, height / 2);
		foreach (KeyValuePair<Vector2, Tile> pair in tiles)
		{
			if (pair.Key.x <= center.x - safezoneRange || pair.Key.x >= center.x + safezoneRange)
			{
				spawnableTiles.Add(pair.Value);
			}
			else if (pair.Key.y <= center.y - safezoneRange || pair.Key.y >= center.y + safezoneRange)
			{
				spawnableTiles.Add(pair.Value);
			}
		}

		GameObject baseTile = Instantiate(basePrefab);
		baseTile.transform.position = new Vector3(width / 2, 0.5f, height / 2);
	}
}