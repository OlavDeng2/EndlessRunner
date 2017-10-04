using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text ScoreText;

    //variables needed for spawning enemies as well as defining the lanes
    public GameObject Enemy = null;
    public GameObject PickUp = null;
    public int LaneDistance = 5;
    public int DestroyTime = 20;
    public int SpawnDistance = 1;

    public float SpawnTime = 1f;

    //initialize the score
    public static int Score = 0;

    // Use this for initialization
    void Start ()
    {
        //start spawning the objects needed for the level
        StartCoroutine(Spawn());

    }
    private void Update()
    {
        ScoreText.text = "Score is: " + Score;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            //get the position for where the enemies or pickups will spawn
            Vector3 spawnPosition = new Vector3(Random.Range(-1, 2) * LaneDistance, 2, SpawnDistance);
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

    public void GameOver()
    {
        //TODO use (and learn) Modal windows
        SceneManager.LoadScene(3);
    }
}
