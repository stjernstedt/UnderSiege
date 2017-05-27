using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float moveSpeed;
	Transform baseCore;
	Vector3 direction;

	// Use this for initialization
	void Start()
	{
		baseCore = FindObjectOfType<Base>().transform;
		direction = baseCore.position - transform.position;
		direction = direction.normalized;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Vector3.Distance(transform.position, baseCore.position) > 1f)
		{
			transform.Translate(direction * moveSpeed);
		}
	}
}
