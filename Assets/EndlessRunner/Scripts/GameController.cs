using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Spawn(enemy));
    }

    // Update is called once per fixed unit of time
    void FixedUpdate ()
    {
    }

    IEnumerator Spawn(GameObject Spawnable)
    {
        while(true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(0, 3), 0, 0);

            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(Spawnable, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }

    }
}
