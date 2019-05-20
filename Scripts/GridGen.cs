using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGen : MonoBehaviour {

    [SerializeField]
    private EssenceHolder essenceHolder;

    [SerializeField]
    private GameObject hexagon;

    [SerializeField]
    private RectTransform parentRect;

    [SerializeField]
    private GridEssences essencesInGrid;
    private GameObject[] hexCells;
    private GameObject[] essObjs;

    private int addHex;

    private float hexWidth = 7;
    private float hexHeight = 7;
    private float xOffset = 85;
    private float yOffset = 100;

    // Use this for initialization
    void Start () {

        xOffset = xOffset * parentRect.localScale.x;
        yOffset = yOffset * parentRect.localScale.y;
        hexagon.transform.localScale = new Vector3(parentRect.localScale.x, parentRect.localScale.y, 1);


        addHex = (int)(hexWidth - 1) / 2;

        for (float i = 0; i < hexWidth; i++)
        {
            hexHeight = (4 + addHex - Mathf.Abs(3 - i));

            for (float j = 0; j < hexHeight; j++)
            {
                float xPos = (i * xOffset);
                float yPos = (j * yOffset);
                
                if (i % 2 == 1)
                {
                    yPos -= yOffset/2;
                }

                if (i >= 2 && i <= 4)
                {
                    yPos -= yOffset;              
                }

                GameObject hexCell = Instantiate(hexagon, new Vector3(xPos, yPos, 0), Quaternion.identity);
                hexCell.transform.SetParent(transform);
                hexCell.transform.position += (transform.position - (new Vector3(xOffset, yOffset/2, 0) * 3));
            }
        }

        this.transform.localScale = new Vector3(0.8f,0.8f,0.8f);

        hexCells = GameObject.FindGameObjectsWithTag("DropSpot");


        OnHexGridImport();
    }

    public void OnHexGridExport()
    {
        // EXPORTS THE ESSENCES TO SCRIPTABLE OBJECT
        essencesInGrid.gridEssences = new Essence[hexCells.Length];
        essencesInGrid.gridLocked = new bool[hexCells.Length];
        //Debug.Log("EXPORTING");
        for (int i = 0; i < hexCells.Length; i++)
        {
            essencesInGrid.gridEssences[i] = hexCells[i].GetComponent<EssenceDropCell>().droppedEssence;
            essencesInGrid.gridLocked[i] = hexCells[i].GetComponent<EssenceDropCell>().locked;
        }
    }

    public void OnHexGridImport()
    {
        //IMPORTS ESSENCES
        essObjs = essenceHolder.essenceGameobjectArray;

        if (essencesInGrid.gridEssences.Length > 0)
        {
            for (int i = 0; i < hexCells.Length; i++)
            {
                hexCells[i].GetComponent<EssenceDropCell>().droppedEssence = essencesInGrid.gridEssences[i];
                hexCells[i].GetComponent<EssenceDropCell>().locked = essencesInGrid.gridLocked[i];

                if (essencesInGrid.gridEssences[i] != null)
                {
                    Debug.Log("it isnt null");
                    Debug.Log(essObjs.Length);
                    //FIND drag n drop based on essence in runtime then set essence
                    for (int j = 0; j < essObjs.Length; j++)
                    {
                        if (essObjs[j].GetComponent<EssenceDisplay>()._essence == essencesInGrid.gridEssences[i])
                        {
                            Debug.Log("setting dragndrop");
                            hexCells[i].GetComponent<EssenceDropCell>().dragNDrop = essObjs[j].GetComponent<DragNDrop>();
                            hexCells[i].GetComponent<EssenceDropCell>().SetLoadEssence();
                        }
                    }
                }
            }
        }
    }
}
