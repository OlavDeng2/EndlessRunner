using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 DistanceFromPlayer = new Vector3(0, 0, 0);

	// Update is called once per frame
	void Update ()
    {
        MoveCamera();
	}

    //Move the camera to follow the player
    void MoveCamera()
    {
        Vector3 CameraPosition = new Vector3(0, 0, 0);
        Vector3 PlayerPosition = new Vector3(0, 0, 0);

        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        CameraPosition = PlayerPosition + DistanceFromPlayer;
        transform.position = CameraPosition;
    }
}
