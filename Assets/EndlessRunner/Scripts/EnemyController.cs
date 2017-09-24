using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    public Vector3 EnemyVelocity = new Vector3(0, 0, 0);
    public Rigidbody EnemyRB;
    public int GameOverScreen = 0;

    private void FixedUpdate()
    {
        EnemyRB.velocity = EnemyVelocity;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided with enemy");
            LoadScene(GameOverScreen);
        }
    }


    private void LoadScene(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
