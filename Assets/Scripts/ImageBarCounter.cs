using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthBarEnergy : MonoBehaviour
{
    [SerializeField] private List<Image> imageBarCounterList;
    private readonly List<Image> disabledImageBarCounterList = new List<Image>();

    public void DisableHealthBar()
    {
        if (imageBarCounterList.Count < 1) return;
        disabledImageBarCounterList.Add(imageBarCounterList[^1]);
        imageBarCounterList[^1].gameObject.SetActive(false);
        imageBarCounterList.RemoveAt(imageBarCounterList.Count - 1);
    }

    public void EnableHealthBar()
    {
        if (imageBarCounterList.Count >= 5) return;
        imageBarCounterList.Add(disabledImageBarCounterList[0]);
        imageBarCounterList[^1].gameObject.SetActive(true);
        disabledImageBarCounterList.RemoveAt(0);
    }
}