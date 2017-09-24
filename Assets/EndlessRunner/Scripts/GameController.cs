using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Enemy;
    public GameObject PickUp;
    public int LaneDistance = 5;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Spawn(Enemy));
        StartCoroutine(Spawn(PickUp));

    }

    // Update is called once per fixed unit of time
    void FixedUpdate ()
    {
    }

    IEnumerator Spawn(GameObject Spawnable)
    {
        while(true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-1, 2) * LaneDistance, 1, 1);

            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(Spawnable, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }

    }
}
