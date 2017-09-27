using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    //define the Pickup Velocity as well as the Rigidbody 
    public Vector3 PickupVelocity = new Vector3(0, 0, 0);
    public Rigidbody PickupRB = null;

    private void FixedUpdate()
    {
        //keep the rigidbody velocity the same as the pickup velocity
        PickupRB.velocity = PickupVelocity;

    }


    void OnTriggerEnter(Collider collision)
    {
        //check if the object that hits the Pickup is the player
        if (collision.gameObject.tag == "Player")
        {
            //Destroy the Pickup and update the score
            GameObject.Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().Score += 1;
        }
    }
}
