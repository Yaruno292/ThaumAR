using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeDisplay : MonoBehaviour {

    public Essence nodeEssence;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Text _text;

    public int amount;

	// Use this for initialization
	void Start () {
        //_image = GetComponent<SpriteRenderer>();
        _image.sprite = nodeEssence.sprite;
        _image.color = nodeEssence.color;
        amount = Random.Range(1,25);
        _text.text = amount.ToString();
	}

    public void UpdateAmount()
    {
        _text.text = amount.ToString();
    }
}
