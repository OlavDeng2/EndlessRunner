﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Floats for the car speeds
    public float CarSpeed = 5f;
    public float StrafeSpeed = 5f;

    //Float for the car position
    Vector3 CarPosition = new Vector3(0 ,0, 0);

    //Data for spawning the bullet
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public float BulletSpeed = 50;

    // Use this for initialization
    void Start ()
    {
        CarPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButton("Left"))
        {
            CarPosition.x -= StrafeSpeed;
            // turn left
        }

        if (Input.GetButton("Right"))
        {
            CarPosition.x += StrafeSpeed;
            //Turn Right
        }

        if (Input.GetButtonDown("Fire"))
        {
            FireGun();
        }
	}

    //update is called at fixed intervals
    private void FixedUpdate()
    {
        MoveCarForwards();
    }


    //Move the car forwards at a fixed speed
    private void MoveCarForwards()
    {
        CarPosition.z += CarSpeed;
        transform.position = CarPosition;
    }

    private void FireGun()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * BulletSpeed;
    }


}
