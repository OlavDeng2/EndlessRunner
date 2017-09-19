using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

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
