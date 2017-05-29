using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float moveSpeed;
	public int damage;
	public GameObject target;
	Vector3 targetVector;
	Vector3 direction;

	// Use this for initialization
	void Start()
	{
		targetVector = target.transform.position + new Vector3(0, 0.5f, 0);
		direction = targetVector - transform.position;
		direction = direction.normalized;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Vector3.Distance(transform.position, targetVector) > 1f)
		{
			transform.Translate(direction * moveSpeed);
		}
		else
		{
			target.GetComponent<Destructible>().Damage(damage);
			Destroy(gameObject);
		}
	}
}
