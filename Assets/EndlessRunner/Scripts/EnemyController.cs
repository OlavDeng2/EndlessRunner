using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector3 EnemyVelocity = new Vector3(0, 0, 0);
    public Rigidbody EnemyRB;

    private void FixedUpdate()
    {
        EnemyRB.velocity = EnemyVelocity;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided with enemy");
        }

        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
