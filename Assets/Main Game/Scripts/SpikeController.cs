using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public List<GameObject> leftSpikes;
    public List<GameObject> rightSpikes;

    private void Awake()
    {
        foreach (var leftSpike in leftSpikes)
        {
            leftSpike.SetActive(false);
        }
        foreach (var rightSpike in rightSpikes)
        {
            rightSpike.SetActive(false);
        }
    }
}
