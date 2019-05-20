using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceDropCell : MonoBehaviour {
    
    public DragNDrop dragNDrop;
    private GridGen gridGen;
    private AudioPlayer audioPlayer;

    private Sprite _defaultImg;
    private Color _defaultColor;
    public Image _img;

    public Essence droppedEssence;

    public bool isDropCell = false;

    private bool drag = false;

    public bool locked = false;

    private bool loaded = false;

    void Start()
    {
        audioPlayer = GameObject.Find("SoundManager").GetComponent<AudioPlayer>();
        gridGen = GameObject.Find("Grid").GetComponent<GridGen>();
        _img = GetComponent<Image>();
        if (loaded == false)
        {
            _defaultImg = _img.sprite;
            _defaultColor = _img.color;
        }
    }

    void Update()
    {
        if (drag && dragNDrop.gameObject.activeSelf == false)
        {
            dragNDrop.MoveClone();
        }
    }

    public void OnIsDrop()
    {
        isDropCell = true;
        //Debug.Log(isDropCell);
    }

    public void OnNotDrop()
    {
        isDropCell = false;
        //Debug.Log(isDropCell);
    }

    public void SetLoadEssence()
    {
        gridGen = GameObject.Find("Grid").GetComponent<GridGen>();
        _img = GetComponent<Image>();
        _defaultImg = _img.sprite;
        _defaultColor = _img.color;
        loaded = true;
        SetEssence();
    }

    public void SetEssence()
    {
        droppedEssence = dragNDrop.gameObject.GetComponent<EssenceDisplay>()._essence;
        _img.sprite = dragNDrop.gameObject.GetComponent<EssenceDisplay>()._essence.sprite;
        _img.color = dragNDrop.gameObject.GetComponent<EssenceDisplay>()._essence.color;
    }

    public void OnPrevGetBack()
    {
        if (this.name == "Hexagon(Clone)")
        {
            droppedEssence.amount += 1;
            dragNDrop.gameObject.GetComponent<EssenceDisplay>().UpdateAmount();
            Debug.Log(dragNDrop.gameObject.GetComponent<EssenceDisplay>()._essence);
        }
    }

    private void GetBack()
    {
        if (this.name == "Hexagon(Clone)")
        {
            //SOUND
            audioPlayer.PlayErase();


            dragNDrop.GetComponent<EssenceDisplay>()._essence.amount += 1;
            dragNDrop.GetComponent<EssenceDisplay>().UpdateAmount();
            GetComponent<EssenceCheckNeighbor>().ResetCell();
        }
        else
        {
            //SOUND
            audioPlayer.PlayZap(0);
        }
    }

    public void OnGetBack()
    {
        //Debug.Log("clicked" + droppedEssence);

        if (droppedEssence != null && locked == false)
        {
            GetBack();
            dragNDrop = null;
            droppedEssence = null;
            _img.sprite = _defaultImg;
            _img.color = _defaultColor;
        }
        gridGen.OnHexGridExport();
    }

    public void OnReDrag()
    {
        if (droppedEssence != null && locked == false)
        {
            GetBack();
            dragNDrop.OnDrag();
            drag = true;
            _img.sprite = _defaultImg;
            _img.color = _defaultColor;
            droppedEssence = null;
        }
        gridGen.OnHexGridExport();
    }

 
    public void OnReDrop()
    {
        if (drag)
        {
            //Debug.Log("drop set");
            dragNDrop.OnDrop();
            drag = false;
            if (droppedEssence == null)
            {
                dragNDrop = null;
                gridGen.OnHexGridExport();
            }
        }
    }
}
