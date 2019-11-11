﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyManager : MonoBehaviour
{
    public GameObject puppy1;
    public GameObject[] puppyspamer;
    public List<GameObject> puppys;
    public List<float> distances;
    public float mindistance;
    public GameObject valla;
    public Vector2 objball;

    // 2 y medio para y 3 para x
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PuppyCreator", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCalculator();
    }
    void PuppyCreator()
    {
        int rdm = Random.Range(0 , 3);
        Instantiate(puppy1, puppyspamer[rdm].transform.position , Quaternion.identity);
    }
    void DistanceCalculator()
    {
        for (int i = 0; i < puppys.Count; i++)
        {
            distances[i] = puppys[i].transform.position.x;
        }
        for (int i = 0; i < distances.Count; i++)
        {
            if (mindistance > distances[i])
            {
                mindistance = distances[i];
            }
        }
        for (int i = 0; i < puppys.Count; i++)
        {
            if (mindistance == puppys[i].transform.position.x)
            {
                objball = new Vector2(puppys[i].transform.position.x, puppys[i].transform.position.y);
            }
        }
    }
}
