using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurst : MonoBehaviour
{
	ParticleSystem fireBurstParticles;

	// Use this for initialization
	void Start()
	{
		fireBurstParticles = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		if (fireBurstParticles.isStopped)
		{
			Destroy(gameObject);
		}
	}
}
