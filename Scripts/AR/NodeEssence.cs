using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEssence : MonoBehaviour {

    private NodeGenerator nodeGen;

    [SerializeField]
    private GameObject essencePrefab;

    [SerializeField]
    public GameObject info;

    private float padding;

    private int decay = 20000;

    public Essence[] nodeEssences;
    public GameObject[] nodeEssenceObjects;

	// Use this for initialization
	void Start () {
        info.SetActive(false);
        nodeEssences = new Essence[Random.Range(1,5)];
        nodeEssenceObjects = new GameObject[nodeEssences.Length];
        nodeGen = GameObject.Find("SpawnManager").GetComponent<NodeGenerator>();

        for (int i = 0; i < nodeEssences.Length; i++)
        {
            nodeEssences[i] = nodeGen.availableEssences[Random.Range(0, nodeGen.availableEssences.Length)];
            /*if ( i > 0 && nodeEssences[i-1] == nodeEssences[i])
            {
                i -= 1;
                return; // or break
            }*/
            GameObject essPrefab = Instantiate(essencePrefab);
            essPrefab.transform.SetParent(info.transform);
            //added this cuz rotation was fckd in spawned structures
            //essPrefab.transform.rotation = Quaternion.Euler(info.transform.rotation.x, info.transform.rotation.y - 180, info.transform.rotation.z);
            //essPrefab.transform.position = info.transform.position;
            essPrefab.GetComponent<NodeDisplay>().nodeEssence = nodeEssences[i];

            nodeEssenceObjects[i] = essPrefab;

            switch (nodeEssences.Length)
            {
                case 1:
                    padding = -0.1f;
                    break;
                case 2:
                    padding = 0.0f;
                    break;
                case 3:
                    padding = 0.1f;
                    break;
                case 4:
                    padding = 0.2f;
                    break;
                default:
                    padding = 0.0f;
                    break;
            }
            //added rotation set
            //essPrefab.transform.rotation = Quaternion.Euler(info.transform.rotation.x, info.transform.rotation.y - 180, info.transform.rotation.z);
                                            //changed this to info
            essPrefab.transform.position = info.transform.position + new Vector3(((float)nodeEssences.Length / 10f + (padding /* start point */)) - (0.4f * i /* between aspects */), -0.5f, 0);
        }
	}

    void FixedUpdate()
    {
        if (decay > 0)
        {
            decay -= 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
