using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Essence", menuName = "Essence")]
public class Essence : ScriptableObject {

    public new string name;
    public string description;

    public Sprite sprite;
    public Color color;

    public int amount;

    public string ess1;
    public string ess2;

    public bool primary = false;
}
