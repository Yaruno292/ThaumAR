using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour {

    private EssenceDisplay essenceDisplay;
    private EssenceDropCell essenceDropCell;
    private GridGen gridGen;
    private AudioPlayer audioPlayer;

    [SerializeField]
    private GameObject essenceImage;
    public GameObject essenceClone;

    private GameObject[] dropSpot;

    private bool drag = false;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        essenceDisplay = GetComponent<EssenceDisplay>();
        gridGen = GameObject.Find("Grid").GetComponent<GridGen>();
        audioPlayer = GameObject.Find("SoundManager").GetComponent<AudioPlayer>();
        dropSpot = GameObject.FindGameObjectsWithTag("DropSpot");

        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MoveClone();
	}

    public void MoveClone()
    {
        if (drag)
        {
            essenceClone.transform.position = Input.mousePosition;
        }
    }

    public void OnDrag()
    {
        if (essenceDisplay._essence.amount > 0)
        {
            drag = true;
            essenceClone = Instantiate(essenceImage, transform);
            essenceClone.transform.SetParent(transform.parent);
            essenceClone.GetComponent<Image>().sprite = essenceDisplay._essence.sprite;
            essenceClone.GetComponent<Image>().color = essenceDisplay._essence.color;

            for (int i = 0; i < dropSpot.Length; i++)
            {
                if (dropSpot[i].GetComponent<EssenceDropCell>().name == "Hexagon(Clone)" && dropSpot[i].GetComponent<EssenceDropCell>().isDropCell)
                {         
                    //SOUND
                    audioPlayer.PlayErase();
                    break;
                }
                else
                {
                    if (i == dropSpot.Length - 1)
                    {
                        //SOUND
                        audioPlayer.PlayZap(0);
                    }
                }
            }
        }
    }

    public void OnDrop()
    {
        //Debug.Log("dropped");
        if (drag)
        {
            drag = false;
            for (int i = 0; i < dropSpot.Length; i++)
            {
                essenceDropCell = dropSpot[i].GetComponent<EssenceDropCell>();
                if (essenceDropCell.isDropCell && essenceDropCell.locked == false)
                {
                    if (essenceDropCell.name == "Hexagon(Clone)" /*&& essenceDropCell.droppedEssence == null*/)
                    {
                        //SOUND
                        audioPlayer.PlayWrite();

                        essenceDisplay._essence.amount -= 1;
                        essenceDisplay.UpdateAmount();
                        if (essenceDropCell.droppedEssence != null)
                        {
                            Debug.Log("gives back");
                            essenceDropCell.OnPrevGetBack();
                            /*
                            essenceDropCell.droppedEssence.amount += 1;
                            essenceDropCell.dragNDrop.gameObject.GetComponent<EssenceDisplay>().UpdateAmount();                        
                            */
                        }
                    }
                    else
                    {
                        audioPlayer.PlayZap(1);
                    }
                    essenceDropCell.dragNDrop = this.gameObject.GetComponent<DragNDrop>(); //Needs the gameobject, gets destroyed when next holders
                    essenceDropCell.SetEssence();
                    if (essenceDropCell.name == "Hexagon(Clone)")
                    {
                        essenceDropCell.GetComponent<EssenceCheckNeighbor>().CheckCell(); //check neighbors NEEDS new essence
                    }
                    Destroy(essenceClone);
                    //Debug.Log("gets called");
                    break;
                }
                if (!essenceDropCell.isDropCell && i >= dropSpot.Length-1)
                {
                    //Debug.Log(essenceDropCell.isDropCell);
                    //Debug.Log("gives back");                    
                    //essenceDisplay._essence.amount += 1;
                    //essenceDisplay.UpdateAmount();
                    Destroy(essenceClone);

                    //SOUND
                    audioPlayer.PlayZap(1);

                    break;
                }
                //Debug.Log(dropSpot.Length + "  " + i);             
            }
            gridGen.OnHexGridExport();
        }
    }
}
