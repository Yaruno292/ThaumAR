using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceDisplay : MonoBehaviour {

    [SerializeField]
    public Essence _essence;

    [SerializeField]
    private Text _text, _amount;

    [SerializeField]
    private Image _essImg , _ess1, _ess2, _textBack;

    [SerializeField]
    private Sprite _default;
    
    [SerializeField]
    private EssenceHolder essenceHolder;

    private EssenceDisplay essenceDisplay;
    //private Image _image;

    private string[] essString;
    private Image[] _essSmallImg;

    // Use this for initialization
    void Start () {
        essenceHolder = GetComponentInParent<EssenceHolder>();
        //_image = GetComponent<Image>();

        _essImg.sprite = _essence.sprite;
        _essImg.color = _essence.color;
        _text.text = _essence.name + "\n" + _essence.description;
        //_text.color = _essence.color;
        _text.gameObject.SetActive(false);
        _textBack.gameObject.SetActive(false);
        _amount.text = _essence.amount.ToString();

        essString = new string[2];
        essString[0] = _essence.ess1;
        essString[1] = _essence.ess2;

        _essSmallImg = new Image[2];
        _essSmallImg[0] = _ess1;
        _essSmallImg[1] = _ess2;

        for (int m = 0; m < 2; m++)
        {
            for (int i = 0; i < essenceHolder.essenceGameobjectArray.Length; i++)
            {
                if (essenceHolder.essenceGameobjectArray[i].GetComponent<EssenceDisplay>()._essence.name == essString[m])
                {
                    essenceDisplay = essenceHolder.essenceGameobjectArray[i].GetComponent<EssenceDisplay>();
                    _essSmallImg[m].sprite = essenceDisplay._essence.sprite;
                    _essSmallImg[m].color = essenceDisplay._essence.color;
                }
                else if (_essence.primary == true)
                {
                    _essSmallImg[m].sprite = null;
                    _essSmallImg[m].color = Color.clear;
                }
                else if (_essSmallImg[m].sprite == null)
                {
                    _essSmallImg[m].sprite = _default;
                    _essSmallImg[m].color = Color.gray;
                }
            }
        }
    }

    public void ActivateText()
    {
        _text.gameObject.SetActive(true);
        _textBack.gameObject.SetActive(true);
    }

    public void DeActivateText()
    {
        _text.gameObject.SetActive(false);
        _textBack.gameObject.SetActive(false);
    }

    public void UpdateAmount()
    {
        _amount.text = _essence.amount.ToString();
    }
}
