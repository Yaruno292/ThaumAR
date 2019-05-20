using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EssenceData {

    public Essence[] knownEssences;
    public int[] amount;

    public EssenceData (EssenceHolder essenceHolder)
    {
        knownEssences = new Essence[essenceHolder.knownEssences.Length];
        amount = new int[essenceHolder.knownEssences.Length];

        for (int i = 0; i < essenceHolder.knownEssences.Length; i++)
        {
            Debug.Log(knownEssences[i]);
            knownEssences[i] = essenceHolder.knownEssences[i];
            amount[i] = essenceHolder.knownEssences[i].amount;
        }
    }
}
