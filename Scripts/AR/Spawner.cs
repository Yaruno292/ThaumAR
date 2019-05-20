using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [Header("Spawn Structure")]

    [SerializeField]
    private GameObject[] spawnPrefab;

    private GameObject spawnObj;

    [SerializeField]
    private GameObject cam;

    private int time = 200;

    private Vector3 randomPos;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (time <= 0)
        {
            time = Random.Range(200, 6000);
            //time = 200;
            spawnObj = spawnPrefab[Random.Range(0, spawnPrefab.Length)];
            randomPos = new Vector3(Random.Range(cam.transform.position.x - 30, cam.transform.position.x + 30), spawnObj.transform.position.y, Random.Range(transform.position.z - 30, transform.position.z + 30));
            Instantiate(spawnObj, randomPos, Quaternion.Euler(0,Random.Range(0,360),0));
        }
        else
        {
            time -= 1;
        }
    }
}
