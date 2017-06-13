using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCenter : Building
{
	public GameObject rocketPrefab;
	public int rockets;
	public int money;

	float bezierStart;
	float bezierMiddle;
	float bezierEnd;

	QuadraticBezierCurve curve;

	float timeBetweenLaunches = 0;
	float timePassed = 0;

	Core core;
	BuildingHandler buildingHandler;

	// Use this for initialization
	void Start()
	{
		core = FindObjectOfType<Core>();
		buildingHandler = core.GetComponent<BuildingHandler>();
	}

	// Update is called once per frame
	void Update()
	{
		timePassed += Time.deltaTime;
		if (Input.GetMouseButtonDown(0))
		{
			LaunchRocket();
		}
	}

	void LaunchRocket()
	{
		if (timePassed > timeBetweenLaunches && !buildingHandler.building)
		{
			if (rockets > 0)
			{
				Vector3 start = transform.position;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				Physics.Raycast(ray, out hit);
				if (hit.collider != null)
				{
					Vector3 end = hit.collider.transform.position;
					end.y = 0;

					Vector3 middle = Vector3.Lerp(start, end, 0.8f);
					middle.y = 20;

					curve = new QuadraticBezierCurve(start, middle, end);

					Rocket rocket = Instantiate(rocketPrefab).GetComponent<Rocket>();
					rocket.target = end;
					rocket.curve = curve;
					rocket.Launch();
					timePassed = 0;
					rockets -= 1;
				}
			}
		}
	}

	public override void Destroyed()
	{

	}
}