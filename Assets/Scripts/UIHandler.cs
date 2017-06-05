using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	public Text rocketsText;
	public Text moneyText;

	public CityCenter cityCenter;
	float timePassed;

	// Use this for initialization
	void Start()
	{
		timePassed = 1;
	}

	// Update is called once per frame
	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			UpdateUI();
		}
	}

	public void UpdateUI()
	{
		rocketsText.text = "Rockets: " + cityCenter.rockets;
		moneyText.text = "Money: " + cityCenter.money;
		timePassed = 0;
	}
}
