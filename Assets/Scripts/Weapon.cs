using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject rocketPrefab;

	float bezierStart;
	float bezierMiddle;
	float bezierEnd;

	QuadraticBezierCurve curve;

	float timeBetweenLaunches = 0;
	float timePassed = 0;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		timePassed += Time.deltaTime;
		if (Input.GetMouseButtonDown(0))
		{
			if (timePassed > timeBetweenLaunches)
			{
				Vector3 start = transform.position;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				Physics.Raycast(ray, out hit);
				Vector3 end = hit.collider.transform.position;
				end.y = 0;

				Vector3 middle = Vector3.Lerp(start, end, 0.5f);
				middle.y = 20;

				curve = new QuadraticBezierCurve(start, middle, end);

				Rocket rocket = Instantiate(rocketPrefab).GetComponent<Rocket>();
				rocket.curve = curve;
				rocket.Launch();
				timePassed = 0;
			}
		}
	}

}