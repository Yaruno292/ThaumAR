using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuggerText : MonoBehaviour {

    [SerializeField]
    private Text text;

    [SerializeField]
    private Text startText;

    [SerializeField]
    private KnownEssences knownEss;

    [SerializeField]
    private GridEssences gridEss;

    [SerializeField]
    private Essence ess;

	// Use this for initialization
	void Start () {
        startText.text = "Grid ess: " + gridEss.gridEssences.Length +
        "\n known ess: " + knownEss.knownEssences.Length;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "DEBUG: \n knownEssLenght: " + knownEss.knownEssences.Length +
        "\n GridEssLenght: " + gridEss.gridEssences.Length + 
        "\n EssSprite: " + ess.sprite + "\n name: " + ess.name + "\n color: " + ess.color;
	}
}
