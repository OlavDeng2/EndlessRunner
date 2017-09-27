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

    void OnTriggerEnter(Collider collision)
    {
        //check if enemy collided with the player
        if (collision.gameObject.tag == "Player")
        {

            //if the enemy collided with the player, call LoadScene
            Debug.Log("Player Collided with enemy");
            LoadScene(GameOverScreen);
        }
    }

    //LoadScene function to load the GameOver scene when losing
    private void LoadScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
