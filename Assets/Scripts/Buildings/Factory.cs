using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
	public float rocketsPerMinute;
	CityCenter cityCenter;
	float timePassed;

	// Use this for initialization
	void Start()
	{
		cityCenter = FindObjectOfType<CityCenter>();
	}

	// Update is called once per frame
	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > (60 / rocketsPerMinute))
		{
			cityCenter.rockets += 1;
			timePassed = 0;
		}
	}

	public override void Destroyed()
	{
		Destroy(gameObject);
	}
}
