﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrower : MonoBehaviour
{
    Tile tile;
    float growSpeed = 0.15f;

    // Use this for initialization
    void Start()
    {
        tile = GetComponent<Tile>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, Time.deltaTime * growSpeed, 0);
        transform.position += new Vector3(0, Time.deltaTime / 2 * growSpeed, 0);

        for (int i = 0; i < tile.innerNeighbours.Count; i++)
        {
            tile.innerNeighbours[i].transform.localScale += new Vector3(0, Time.deltaTime / 2 * growSpeed, 0);
            tile.innerNeighbours[i].transform.position += new Vector3(0, Time.deltaTime / 4 * growSpeed, 0);
        }

        for (int i = 0; i < tile.outerNeighbours.Count; i++)
        {
            tile.outerNeighbours[i].transform.localScale += new Vector3(0, Time.deltaTime / 4 * growSpeed, 0);
            tile.outerNeighbours[i].transform.position += new Vector3(0, Time.deltaTime / 8 * growSpeed, 0);
        }
    }
}