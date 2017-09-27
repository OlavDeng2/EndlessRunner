﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    //variables needed for spawning enemies as well as defining the lanes
    public GameObject Enemy = null;
    public GameObject PickUp = null;
    public int LaneDistance = 5;
    public int DestroyTime = 20;

    public float SpawnTime = 1f;

    //initialize the score
    public int Score = 0;

    // Use this for initialization
    void Start ()
    {
        //start spawning the objects needed for the level
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            //get the position for where the enemies or pickups will spawn
            Vector3 spawnPosition = new Vector3(Random.Range(-1, 2) * LaneDistance, 1, 1);
            // get the rotation for the objects
            Quaternion spawnRotation = Quaternion.identity;

            //random number to determine whether to spawn enemy or pickup then spawn them
            if( Random.Range(0, 2) == 0)
            {
                GameObject EnemyObject = Instantiate(Enemy, spawnPosition, spawnRotation);
                Destroy(EnemyObject, DestroyTime);
            }
            else
            {
                GameObject PickUpObject = Instantiate(PickUp, spawnPosition, spawnRotation);
                Destroy(PickUpObject, DestroyTime);
            }

            //wait a random amount of time before spawning the next object
            yield return new WaitForSeconds(SpawnTime);
        }

    }
}
