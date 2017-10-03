using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    //Define variables for velocity of enemy as well as its rigid body
    public Vector3 EnemyVelocity = new Vector3(0, 0, 0);
    public Rigidbody EnemyRB;
    public int GameOverScreen = 0;

    private void FixedUpdate()
    {
        //set the velocity of the rigidbody to be the same as the velocity defined in the inspector
        EnemyRB.velocity = EnemyVelocity;

    }

}
