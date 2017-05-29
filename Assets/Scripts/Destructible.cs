using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
	public int maxHealth;
	public int health;

	// Use this for initialization
	void Start()
	{
		health = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Damage(int damage)
	{
		health -= damage;

	}
}
