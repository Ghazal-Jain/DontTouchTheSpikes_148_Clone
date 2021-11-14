using System;
using System.Collections;
using System.Collections.Generic;
using Main_Game.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;


public enum Spike
{
    Left,
    Right
};


public class SpikeController : MonoBehaviour
{
    public List<GameObject> leftSpikes;
    public List<GameObject> rightSpikes;
    
    private void Awake()
    {
        HideLeftSpikes();
        HideRightSpikes();
    }

    private void Start()
    {
        GenerateSpike(Spike.Right,1);
    }

    public void GenerateSpike(Spike type,int level)
    {
        int x, y;
        switch (type)
        {
            case Spike.Left:
                x = Random.Range(0, leftSpikes.Count);
                y = Random.Range(0, leftSpikes.Count);
                if (x == y)
                {
                    
                }
                leftSpikes[x].SetActive(true);
                leftSpikes[y].SetActive(true);
                break;
            case Spike.Right:
                x = Random.Range(0, rightSpikes.Count);
                y = Random.Range(0, rightSpikes.Count);
                if (x == y)
                {
                    
                }
                rightSpikes[x].SetActive(true);
                rightSpikes[y].SetActive(true);
                break;
        }
    }

    public void HideLeftSpikes()
    {
        foreach (var leftSpike in leftSpikes)
        {
            leftSpike.SetActive(false);
        }
    }

    public void HideRightSpikes()
    {
        foreach (var rightSpike in rightSpikes)
        {
            rightSpike.SetActive(false);
        }
    }
}
