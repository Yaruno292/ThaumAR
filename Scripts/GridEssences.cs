using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New GridEssences", menuName = "GridEssences")]
public class GridEssences : ScriptableObject {

    public Essence[] gridEssences;
    public bool[] gridLocked;
}
