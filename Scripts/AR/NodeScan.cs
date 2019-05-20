using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeScan : MonoBehaviour {

    [SerializeField]
    private GameObject info;

    [SerializeField]
    private GameObject cam;

    private NodeDisplay nodeDisplay;
    private NodeEssence nodeEssence;
    private MobileInput mobileInput;

    [SerializeField]
    private KnownEssences knownEssences;

    public float drainPower = 1f;

    private bool onScan = false;

    private float range = 5f;
    private float time = 0;

    private bool OneTimeRun = false;

    private Essence[] essencesScanned;
    private int[] essencesAmount;

    void Start()
    {
        mobileInput = GetComponent<MobileInput>();
    }

    public void OnScanObj()
    {
        onScan = true;
    }

    public void OnNotScanObj()
    {
        onScan = false;
    }

    void Update()
    {
        //Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), Color.red);
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            if (hit.collider.tag == "Node")
            {
                if (nodeEssence != null)
                {
                    info.SetActive(false);
                }
                nodeEssence = hit.collider.gameObject.GetComponent<NodeEssence>();

                info = nodeEssence.info;
                info.SetActive(true);

                if (onScan) //IF SCANNING
                {
                    //Debug.Log("gets scanned");
                    if (time <= 0)
                    {
                        //Debug.Log("timer is 0");
                        time = drainPower;
                        for (int i = 0; i < nodeEssence.nodeEssenceObjects.Length; i++)
                        {
                            nodeDisplay = nodeEssence.nodeEssenceObjects[i].GetComponent<NodeDisplay>();

                            if (!OneTimeRun)
                            {
                                OneTimeRun = true;
                                essencesScanned = new Essence[nodeEssence.nodeEssenceObjects.Length];
                                essencesAmount = new int[nodeEssence.nodeEssenceObjects.Length];
                                for (int j = 0; j < essencesScanned.Length; j++)
                                {
                                    bool gotten = true;
                                    for (int k = 0; k < knownEssences.knownEssences.Length; k++)
                                    {
                                        if (nodeEssence.nodeEssences[j] == knownEssences.knownEssences[k])
                                        {
                                            gotten = true;
                                            Debug.Log("GET IT");
                                            break;
                                        }
                                        else
                                        {
                                            gotten = false;
                                        }
                                    }
                                    if (!gotten)
                                    {
                                        Essence[] temp = new Essence[knownEssences.knownEssences.Length + 1];
                                        knownEssences.knownEssences.CopyTo(temp, 0);
                                        knownEssences.knownEssences = temp;

                                        knownEssences.knownEssences[knownEssences.knownEssences.Length-1] = nodeEssence.nodeEssences[j];
                                    }
                                }
                            }

                            if (nodeDisplay.amount > 0)
                            {
                                essencesScanned[i] = nodeDisplay.nodeEssence;
                                nodeDisplay.amount -= 1;
                                nodeDisplay.UpdateAmount();
                                essencesAmount[i] += 1;
                                nodeEssence.nodeEssences[i].amount += 1;
                                mobileInput.Vibrate();
                            }
                            Debug.Log(essencesScanned[i] + " " + essencesAmount[i].ToString()); //INFO OUTPUT essence + amount
                        }
                    }
                    else
                    {
                        //Debug.Log("timer goes down");
                        time -= Time.deltaTime;
                    }
                }
            }
            else
            {
                //if its not a node
                if (nodeEssence != null)
                {
                    info.SetActive(false);
                }
            }
        }
        else
        {
            if (nodeEssence != null)
            {
                info.SetActive(false);
            }

            if (OneTimeRun)
            {
                OneTimeRun = false; //resets
            }
        }
    }
}
