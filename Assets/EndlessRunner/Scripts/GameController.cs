using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Enemy;
    public GameObject PickUp;
    public int LaneDistance = 5;

    public int Score = 0;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-1, 2) * LaneDistance, 1, 1);

            Quaternion spawnRotation = Quaternion.identity;
            if( Random.Range(0, 2) == 0)
            {
                Instantiate(Enemy, spawnPosition, spawnRotation);
            }
            else
            {
                Instantiate(PickUp, spawnPosition, spawnRotation);
            }

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }

    }
}
