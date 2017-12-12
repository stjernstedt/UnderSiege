using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
	public GameObject factoryPrefab;
	public GameObject residentalPrefab;
	public LayerMask rayHitLayers;

	Building[] buildings;
	List<GameObject> buildableTiles = new List<GameObject>();
	GameObject currentlyBuilding;

	public bool building = false;

	float timePassed;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (building)
		{
			if (timePassed > 0.2f)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					if (buildableTiles.Contains(hit.collider.gameObject))
					{
						Vector3 buildingPos = hit.collider.transform.position;
						buildingPos.y = 0.5f;
						currentlyBuilding.transform.position = buildingPos;
					}
				}
			}
			timePassed++;

			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 1000f, rayHitLayers))
				{
					if (buildableTiles.Contains(hit.collider.gameObject))
					{
						currentlyBuilding.GetComponent<Building>().enabled = true;
						currentlyBuilding = null;
						ClearPlacementGrid();
						//to prevent rocket being fired after placing building
						StartCoroutine(TurnOffBuildingTimer());
					}
				}
			}

			if (Input.GetMouseButtonDown(1))
			{
				foreach (GameObject tile in buildableTiles)
				{
					tile.GetComponent<Tile>().ResetColor();
				}
				building = false;
				Destroy(currentlyBuilding);
			}
		}
	}

	IEnumerator TurnOffBuildingTimer()
	{
		yield return new WaitForFixedUpdate();
		building = false;
	}

	public void DrawPlacementGrid()
	{
		building = true;
		buildings = FindObjectsOfType<Building>();

		foreach (Building building in buildings)
		{
			foreach (Tile tile in MapGenerator.tiles[new Vector2((int)building.transform.position.x, (int)building.transform.position.z)].innerNeighbours)
			{
				buildableTiles.Add(tile.gameObject);
			}
		}

		buildableTiles = buildableTiles.Distinct().ToList();

		foreach (Building building in buildings)
		{
			buildableTiles.Remove(MapGenerator.tiles[new Vector2((int)building.transform.position.x, (int)building.transform.position.z)].gameObject);
		}

		foreach (GameObject tile in buildableTiles)
		{
			tile.GetComponent<MeshRenderer>().material.color = Color.cyan;
		}
	}

	void ClearPlacementGrid()
	{
		foreach (GameObject tile in buildableTiles)
		{
			tile.GetComponent<Tile>().ResetColor();
		}
	}

	public void BuildFactory()
	{
		DrawPlacementGrid();
		currentlyBuilding = Instantiate(factoryPrefab);

	}

	public void BuildResidental()
	{
		DrawPlacementGrid();
		currentlyBuilding = Instantiate(residentalPrefab);

	}
}
