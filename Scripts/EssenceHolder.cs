using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceHolder : MonoBehaviour {

    [SerializeField]
    private GameObject essencePrefab;

    [SerializeField]
    private RectTransform parentRect;

    private RectTransform rt;

    public GameObject[] essenceGameobjectArray;

    [SerializeField]
    private KnownEssences knownEss;

    public Essence[] knownEssences;

    private float xOffset = 100;
    private float yOffset = 100;

    private float xPos;
    private float yPos;

    private int j = -1;
    private int l = 0;

    private int minDis = 0;
    private int maxDis = 16;

    private int renderFix = 0;

    void Start()
    {
        rt = GetComponent<RectTransform>();

        /*
        xOffset = xOffset * parentRect.localScale.x;
        yOffset = yOffset * parentRect.localScale.y;
        essencePrefab.transform.localScale = new Vector3(parentRect.localScale.x, parentRect.localScale.y, 1);
        */

        knownEssences = new Essence[knownEss.knownEssences.Length];

        for (int i = 0; i < knownEss.knownEssences.Length; i++)
        {
            knownEssences[i] = knownEss.knownEssences[i];
        }

        RenderEssGrid();
    }

    private void RenderEssGrid()
    {
        //Debug.Log(minDis + " " + maxDis + " Render grid");
        //Debug.Log("GRID RENDER" + renderFix);
        //Checks if rendering was already completed
        if (knownEssences.Length < maxDis)
        {
            maxDis = knownEssences.Length;
        }

        if (renderFix >= maxDis)
        {
            for (int i = minDis; i < maxDis; i++)
            {
                essenceGameobjectArray[i].SetActive(true);
            }
            return;
        }
      
        //Render sizes
        this.transform.localScale = new Vector3(1f, 1f, 1f);

        xOffset = 100;
        yOffset = 100;
        xOffset = xOffset * parentRect.localScale.x;
        yOffset = yOffset * parentRect.localScale.y;
        essencePrefab.transform.localScale = new Vector3(parentRect.localScale.x, parentRect.localScale.y, 1);

        //If first render, render piece
        j = -1;
        l = 0;

        for (int i = minDis; i < /*knownEssences.Length*/maxDis; i++)
        {

            if (j == 3)
            {
                l += 1;
                j = 0;
            }
            else
            {
                j += 1;
            }

            xPos = xOffset * j;
            yPos = -yOffset * l;

            GameObject essenceObj = Instantiate(essencePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            if (renderFix >= 16)
            {
                essencePrefab.transform.localScale = new Vector3(parentRect.localScale.x, parentRect.localScale.y, 1);
            }
            essenceObj.transform.SetParent(transform);
            essenceObj.transform.position += transform.position - (new Vector3(xOffset * 1.5f, -yOffset * 1.5f, 0));
            //essenceObj.transform.position += (transform.position - (new Vector3((rt.rect.width / 2) - (xOffset ), (-rt.rect.height / 2) + (yOffset ), 0)));

            essenceObj.GetComponent<EssenceDisplay>()._essence = knownEssences[i];
        }
        //this.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f); 


        if (renderFix >= 16)
        {
            GameObject[] temp = new GameObject[essenceGameobjectArray.Length + GameObject.FindGameObjectsWithTag("Essence").Length];
            int tempLenght = essenceGameobjectArray.Length;
            essenceGameobjectArray.CopyTo(temp, 0);
            essenceGameobjectArray = GameObject.FindGameObjectsWithTag("Essence");
            essenceGameobjectArray.CopyTo(temp, tempLenght);
            essenceGameobjectArray = temp;
        }
        else
        {
            essenceGameobjectArray = GameObject.FindGameObjectsWithTag("Essence");
        }
        this.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        if (renderFix < knownEssences.Length)
        {
            renderFix += 16;
        }
    }

    public void OnNextDis()
    {      
        if (maxDis + 16 <= knownEssences.Length)
        {
            DestroyDis();
            minDis += 16;
            maxDis += 16;
            RenderEssGrid();
        }
        else
        {
            DestroyDis();
            if (minDis + 16 < knownEssences.Length)
            {
                minDis += 16;
            }
            maxDis = knownEssences.Length;
            RenderEssGrid();
        }
    }

    public void OnPrevDis()
    {
        if (minDis - 16 >= 0)
        {
            DestroyDis();
            if (maxDis == knownEssences.Length)
            {
                maxDis = minDis + 16;
            }
            minDis -= 16;
            maxDis -= 16;
            RenderEssGrid();
        }
    }

    private void DestroyDis()
    {
        for (int i = 0; i < essenceGameobjectArray.Length; i++)
        {
            //Destroy(essenceGameobjectArray[i]);
            essenceGameobjectArray[i].SetActive(false);
            essenceGameobjectArray[i].GetComponent<DragNDrop>().enabled = true;
        }
    }
}
