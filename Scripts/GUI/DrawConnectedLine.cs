using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawConnectedLine : MonoBehaviour {

    private EssenceCheckNeighbor essCheckNeighbor;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Image line;

    void Start()
    {
        essCheckNeighbor = GetComponent<EssenceCheckNeighbor>();
    }

    public void DrawLine()
    {
        if (essCheckNeighbor.otherEss != null)
        {
            target = essCheckNeighbor.otherEss.gameObject.transform;
            Image img = Instantiate(line, transform);
            //img.transform.LookAt(target);
        }
    }

    public void RemoveLine()
    {
        //Destroy(img);
    }

    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}
