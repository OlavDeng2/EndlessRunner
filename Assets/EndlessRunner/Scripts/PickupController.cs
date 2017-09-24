using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Vector3 PickupVelocity = new Vector3(0, 0, 0);
    public Rigidbody PickupRB;

    private void FixedUpdate()
    {
        PickupRB.velocity = PickupVelocity;

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
