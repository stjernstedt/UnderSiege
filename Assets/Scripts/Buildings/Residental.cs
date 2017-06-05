using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residental : Building
{
	CityCenter cityCenter;
	public int incomePerMinute;
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
		if (timePassed > (60 / incomePerMinute))
		{
			cityCenter.money += 1;
			timePassed = 0;
		}
	}

	public override void Destroyed()
	{
		Destroy(gameObject);
	}
}
