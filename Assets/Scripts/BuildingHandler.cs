using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
	Building[] buildings;
	MapGenerator mapGenerator;

	// Use this for initialization
	void Start()
	{
		//mapGenerator = GetComponent<MapGenerator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DrawPlacementGrid()
	{
		buildings = FindObjectsOfType<Building>();
		List<Tile> tiles = new List<Tile>();

		foreach (Building building in buildings)
		{
			foreach (Tile tile in MapGenerator.tiles[new Vector2((int)building.transform.position.x, (int)building.transform.position.z)].innerNeighbours)
			{
				tiles.Add(tile);
			}
		}

		tiles = tiles.Distinct().ToList();

		foreach (Building building in buildings)
		{
			tiles.Remove(MapGenerator.tiles[new Vector2((int)building.transform.position.x, (int)building.transform.position.z)]);
		}

		foreach (Tile tile in tiles)
		{
			tile.GetComponent<MeshRenderer>().material.color = Color.cyan;
		}
	}
}
