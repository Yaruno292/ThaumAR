using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] nodePrefab;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    public Essence[] availableEssences;

    [SerializeField]
    private bool locationSpawn = false;

    [SerializeField]
    private Transform[] locations;
    
    private int time = 200;

    private Vector3 randomPos;

    private void Start()
    {
        if (locationSpawn)
        {
            for (int i = 0; i < locations.Length; i++)
            {

                Instantiate(nodePrefab[Random.Range(0, nodePrefab.Length)], locations[i].position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (!locationSpawn)
        {
            if (time <= 0)
            {
                time = Random.Range(200, 6000);
                //time = 200;
                randomPos = new Vector3(Random.Range(cam.transform.position.x - 30, cam.transform.position.x + 30), Random.Range(cam.transform.position.y, transform.position.y + 10), Random.Range(transform.position.z - 30, transform.position.z + 30));
                Instantiate(nodePrefab[Random.Range(0, nodePrefab.Length)], randomPos, Quaternion.identity);
            }
            else
            {
                time -= 1;
            }
        }
	}
}
