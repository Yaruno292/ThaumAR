using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineEssence : MonoBehaviour {

    [SerializeField]
    private EssenceDropCell _ess1, _ess2;

    [SerializeField]
    private EssenceHolder essenceHolder;

    private AudioPlayer audioPlayer;

    private bool part1 = false;
    private bool part2 = false;

    private string createEssence;

    private void Start()
    {
        audioPlayer = GameObject.Find("SoundManager").GetComponent<AudioPlayer>();
    }

    public void Combine()
    {
        for (int i = 0; i < essenceHolder.knownEssences.Length; i++)
        {
            if (_ess1.droppedEssence != null && _ess2.droppedEssence != null)
            {
                if (_ess1.droppedEssence.name == essenceHolder.knownEssences[i].ess1 || _ess1.droppedEssence.name == essenceHolder.knownEssences[i].ess2)
                {
                    Debug.Log("FOUND!");
                    part1 = true;
                }

                if (_ess2.droppedEssence.name == essenceHolder.knownEssences[i].ess1 || _ess2.droppedEssence.name == essenceHolder.knownEssences[i].ess2)
                {
                    Debug.Log("Found 2!");
                    part2 = true;
                }
            }
        }

        if (part1 && part2)
        {
            part1 = false;
            part2 = false;

            for (int i = 0; i < essenceHolder.knownEssences.Length; i++)
            {
                if (essenceHolder.knownEssences[i].ess1 == _ess1.droppedEssence.name || essenceHolder.knownEssences[i].ess1 == _ess2.droppedEssence.name)
                {
                    for (int j = 0; j < essenceHolder.knownEssences.Length; j++)
                    {
                        if (essenceHolder.knownEssences[j].ess2 == _ess1.droppedEssence.name || essenceHolder.knownEssences[j].ess2 == _ess2.droppedEssence.name)
                        {
                            Debug.Log("Creating");
                            if (essenceHolder.knownEssences[i].name == essenceHolder.knownEssences[j].name)
                            {
                                createEssence = essenceHolder.knownEssences[j].name;
                                Debug.Log(createEssence);
                                for (int k = 0; k < essenceHolder.knownEssences.Length; k++)
                                {
                                    if (essenceHolder.knownEssences[k].name == createEssence && _ess1.droppedEssence.amount > 0 && _ess2.droppedEssence.amount > 0)
                                    {

                                        //SOUND
                                        audioPlayer.PlayLearn();


                                        if (_ess1.droppedEssence != _ess2.droppedEssence)
                                        {
                                            essenceHolder.knownEssences[k].amount += 1;
                                            _ess1.droppedEssence.amount -= 1;
                                            _ess2.droppedEssence.amount -= 1;
                                            _ess1.dragNDrop.gameObject.GetComponent<EssenceDisplay>().UpdateAmount();
                                            _ess2.dragNDrop.gameObject.GetComponent<EssenceDisplay>().UpdateAmount();
                                            essenceHolder.essenceGameobjectArray[k].GetComponent<EssenceDisplay>().UpdateAmount();
                                            break;
                                        }
                                        else if (_ess1.droppedEssence.amount > 1)
                                        {
                                            essenceHolder.knownEssences[k].amount += 1;
                                            _ess1.droppedEssence.amount -= 1;
                                            _ess2.droppedEssence.amount -= 1;
                                            _ess1.dragNDrop.gameObject.GetComponent<EssenceDisplay>().UpdateAmount();
                                            _ess2.dragNDrop.gameObject.GetComponent<EssenceDisplay>().UpdateAmount();
                                            essenceHolder.essenceGameobjectArray[k].GetComponent<EssenceDisplay>().UpdateAmount();
                                            break;
                                        }                   
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
