using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	Color originalColor;
	Material material;
	Vector3 originalPosition;

	//MapGenerator mapGenerator;

	Vector2[] innerCircle = { new Vector2(+1, 0), new Vector2(+1, +1), new Vector2(0, +1), new Vector2(-1, +1), new Vector2(-1, 0), new Vector2(-1, -1), new Vector2(0, -1), new Vector2(+1, -1) };
	Vector2[] outerCircle = { new Vector2(+2, 0), new Vector2(+2, +1), new Vector2(+2, +2), new Vector2(+1, +2), new Vector2(0, +2), new Vector2(-1, +2), new Vector2(-2, +2), new Vector2(-2, +1), new Vector2(-2, 0), new Vector2(-2, -1), new Vector2(-2, -2), new Vector2(-1, -2), new Vector2(+0, -2), new Vector2(+1, -2), new Vector2(+2, -2), new Vector2(+2, -1) };

	public Vector2 tileKey;
	public List<Tile> innerNeighbours = new List<Tile>();
	public List<Tile> outerNeighbours = new List<Tile>();

	// Use this for initialization
	void Awake()
	{
		material = GetComponent<MeshRenderer>().material;
		originalColor = material.color;
		originalPosition = transform.position;
		//mapGenerator = FindObjectOfType<MapGenerator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.localScale.y > 1)
		{
			float lerpPosition = transform.localScale.y / 5;
			material.color = Color.Lerp(originalColor, Color.red, lerpPosition);
		}
		if (transform.localScale.y > 5)
		{
			ResetTile();
		}
	}

	public void ResetTile()
	{
		transform.localScale = new Vector3(1, 1, 1);
		transform.position = originalPosition;
		material.color = originalColor;
		Destroy(GetComponent<TileGrower>());
	}

	public void CalculateNeighbours()
	{
		foreach (Vector2 direction in innerCircle)
		{
			if (MapGenerator.tiles.ContainsKey(tileKey + direction))
			{
				innerNeighbours.Add(MapGenerator.tiles[tileKey + direction]);
			}
		}

		foreach (Vector2 direction in outerCircle)
		{
			if (MapGenerator.tiles.ContainsKey(tileKey + direction))
			{
				outerNeighbours.Add(MapGenerator.tiles[tileKey + direction]);
			}
		}
	}
}
