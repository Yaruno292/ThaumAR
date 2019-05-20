using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLookAtCam : MonoBehaviour {

    private GameObject cam;
    private SpriteRenderer sprite;

    [SerializeField]
    private SpriteRenderer coreSprite;

    private Color color = Color.white;

    private float distance;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        sprite = GetComponent<SpriteRenderer>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(cam.transform);

        distance = Vector3.Distance(cam.transform.position, transform.position);
        color.a = 5/distance;
        sprite.color = color;
        coreSprite.color = color;
	}
}
