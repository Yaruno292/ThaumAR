using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceCheckNeighbor : MonoBehaviour {

    private DrawConnectedLine drawLine;

    private GameObject[] hexCells;

    private int currentCell;

    public int connectedLocked = 0;

    private int rownum = 0;
    private int fixer = 0;

    private EssenceDropCell currentEss;

    public EssenceDropCell otherEss;

    // Use this for initialization
    void Start () {
        drawLine = GetComponent<DrawConnectedLine>();
        hexCells = GameObject.FindGameObjectsWithTag("DropSpot");
        for (int i = 0; i < hexCells.Length; i++)
        {
            if (hexCells[i].transform == this.transform)
            {
                currentCell = i;
                currentEss = hexCells[i].GetComponent<EssenceDropCell>();
                break;
            }
        }
        if (hexCells[currentCell].GetComponent<EssenceDropCell>().locked == true)
        {
            connectedLocked = 1;
        }
        //Debug.Log(currentCell);

    }

    public void ResetCell ()
    {
        rownum = 0;
        fixer = 0;
    }

	public void CheckCell () {
        
        if (currentCell > 5 && rownum <= 3)
        {
            rownum += 1;
            if (currentCell > 10 && currentCell < 35)
            {
                rownum += 1;
                if (currentCell > 16 && currentCell < 30)
                {
                    rownum += 1;
                    fixer += 1;             
                }
                if (currentCell > 24)
                {
                    fixer += 1;
                    if (currentCell > 30)
                    {
                        fixer += 1;
                    }
                }
            }
        }
        Debug.Log(rownum);
        if (hexCells[currentCell].GetComponent<EssenceDropCell>().droppedEssence != null)
        {
            //DOWN
            if (currentCell > 0 && hexCells[currentCell - 1].GetComponent<EssenceDropCell>().droppedEssence != null) //UP
            {
                otherEss = hexCells[currentCell - 1].GetComponent<EssenceDropCell>();
                Debug.Log("Found Downer");
                if (otherEss.droppedEssence.name == currentEss.droppedEssence.ess1 || otherEss.droppedEssence.name == currentEss.droppedEssence.ess2 || otherEss.droppedEssence.ess1 == currentEss.droppedEssence.name || otherEss.droppedEssence.ess2 == currentEss.droppedEssence.name)
                {
                    Debug.Log("Connection made");
                    drawLine.DrawLine();
                    if (otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked > 0)
                    {
                        otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked -= 1;
                        connectedLocked += 1;
                    }
                }
            }

            //UP
            if(currentCell < hexCells.Length - 1 && hexCells[currentCell + 1].GetComponent<EssenceDropCell>().droppedEssence != null) //Down
            {
                otherEss = hexCells[currentCell + 1].GetComponent<EssenceDropCell>();
                Debug.Log("Found Upper");
                if (otherEss.droppedEssence.name == currentEss.droppedEssence.ess1 || otherEss.droppedEssence.name == currentEss.droppedEssence.ess2 || otherEss.droppedEssence.ess1 == currentEss.droppedEssence.name || otherEss.droppedEssence.ess2 == currentEss.droppedEssence.name)
                {
                    Debug.Log("Connection made");
                    drawLine.DrawLine();
                    if (otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked > 0)
                    {
                        otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked -= 1;
                        connectedLocked += 1;
                    }
                }
            }

            //BOTTOM LEFT
            if (currentCell - rownum - 4 > 0 && hexCells[currentCell - rownum - 4].GetComponent<EssenceDropCell>().droppedEssence != null)
            {
                otherEss = hexCells[currentCell - rownum - 4].GetComponent<EssenceDropCell>();
                Debug.Log("Bottom Left");
                if (otherEss.droppedEssence.name == currentEss.droppedEssence.ess1 || otherEss.droppedEssence.name == currentEss.droppedEssence.ess2 || otherEss.droppedEssence.ess1 == currentEss.droppedEssence.name || otherEss.droppedEssence.ess2 == currentEss.droppedEssence.name)
                {
                    Debug.Log("Connection made");
                    drawLine.DrawLine();
                    if (otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked > 0)
                    {
                        otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked -= 1;
                        connectedLocked += 1;
                    }
                }
            }

            //BOTTOM RIGHT
            if (currentCell + rownum + 4 - fixer < hexCells.Length && hexCells[currentCell + rownum + 4 - fixer].GetComponent<EssenceDropCell>().droppedEssence != null)
            {
                otherEss = hexCells[currentCell + rownum + 4 - fixer].GetComponent<EssenceDropCell>();
                Debug.Log("Bottom Right");
                if (otherEss.droppedEssence.name == currentEss.droppedEssence.ess1 || otherEss.droppedEssence.name == currentEss.droppedEssence.ess2 || otherEss.droppedEssence.ess1 == currentEss.droppedEssence.name || otherEss.droppedEssence.ess2 == currentEss.droppedEssence.name)
                {
                    Debug.Log("Connection made");
                    drawLine.DrawLine();
                    if (otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked > 0)
                    {
                        otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked -= 1;
                        connectedLocked += 1;
                    }
                }
            }

            //TOP LEFT
            if (currentCell - rownum - 3 > 0 && hexCells[currentCell - rownum - 3].GetComponent<EssenceDropCell>().droppedEssence != null)
            {
                otherEss = hexCells[currentCell - rownum - 3].GetComponent<EssenceDropCell>();
                Debug.Log("Top Left");
                if (otherEss.droppedEssence.name == currentEss.droppedEssence.ess1 || otherEss.droppedEssence.name == currentEss.droppedEssence.ess2 || otherEss.droppedEssence.ess1 == currentEss.droppedEssence.name || otherEss.droppedEssence.ess2 == currentEss.droppedEssence.name)
                {
                    Debug.Log("Connection made");
                    drawLine.DrawLine();
                    if (otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked > 0)
                    {
                        otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked -= 1;
                        connectedLocked += 1;
                    }
                }
            }

            //TOP RIGHT
            if (currentCell + rownum + 5 - fixer < hexCells.Length && hexCells[currentCell + rownum + 5 - fixer].GetComponent<EssenceDropCell>().droppedEssence != null)
            {
                otherEss = hexCells[currentCell + rownum + 5 - fixer].GetComponent<EssenceDropCell>();
                Debug.Log("Top Right");
                if (otherEss.droppedEssence.name == currentEss.droppedEssence.ess1 || otherEss.droppedEssence.name == currentEss.droppedEssence.ess2 || otherEss.droppedEssence.ess1 == currentEss.droppedEssence.name || otherEss.droppedEssence.ess2 == currentEss.droppedEssence.name)
                {
                    Debug.Log("Connection made");
                    drawLine.DrawLine();
                    if (otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked > 0)
                    {
                        otherEss.GetComponent<EssenceCheckNeighbor>().connectedLocked -= 1;
                        connectedLocked += 1;
                    }
                }
            }
            Debug.Log(connectedLocked);
        }
	}
}
