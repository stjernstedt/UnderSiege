﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public QuadraticBezierCurve curve;
    public Vector3 target;
    public GameObject particleSystem;

    float timeToMove = 2;
    float timePassed;

    bool launched = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (launched)
        {
            timePassed += Time.deltaTime;
            transform.position = curve.GetQuadraticBezierPoint(timePassed / timeToMove);
            if (timePassed > timeToMove)
            {
                Hit();
                Destroy(gameObject);
            }
        }

    }

    public void Launch()
    {
        launched = true;
    }

    void Hit()
    {
        //Tile tile = MapGenerator.tiles[new Vector2(Mathf.CeilToInt(transform.position.x), Mathf.CeilToInt(transform.position.z))];
        Tile tile = MapGenerator.tiles[new Vector2(Mathf.CeilToInt(target.x), Mathf.CeilToInt(target.z))];
        tile.ResetTile();
        GameObject particles = Instantiate(particleSystem);
        particles.transform.position = target + new Vector3(0, 1, 0);
        foreach (Tile neighbour in tile.innerNeighbours)
        {
            neighbour.ResetTile();
        }
    }
}
