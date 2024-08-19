using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageBarCounter : MonoBehaviour
{
    [SerializeField] private List<Image> imageBarCounterList;
    private List<Image> disabledImageBarCounterList = new List<Image>();
    private int shield;
    private Color defaultColor;

    public void Start()
    {
        defaultColor = imageBarCounterList[0].color;
    }

    public void DisableImageBar()
    {
        if (imageBarCounterList.Count < 1) return;
        disabledImageBarCounterList.Add(imageBarCounterList[^1]);
        imageBarCounterList[^1].gameObject.SetActive(false);
        imageBarCounterList.RemoveAt(imageBarCounterList.Count - 1);
        imageBarCounterList = imageBarCounterList.OrderBy(go => go.name).ToList();
        disabledImageBarCounterList = disabledImageBarCounterList.OrderBy(go => go.name).ToList();
    }

    public void EnableImageBar()
    {
        if (imageBarCounterList.Count >= 5) return;
        imageBarCounterList.Add(disabledImageBarCounterList[0]);
        imageBarCounterList[^1].gameObject.SetActive(true);
        disabledImageBarCounterList.RemoveAt(0);
    }

    public void EnableShieldImageBar()
    {
        shield++;
        for (int i = 0; i < shield; i++)
        {
            imageBarCounterList[i].color = Color.green;
        }
    }

    public void DisableShieldImageBar()
    {
        shield--;
        imageBarCounterList[shield].color = defaultColor;
    }

    public void OverheatImageBar()
    {
        StartCoroutine(Overheat());
    }

    IEnumerator Overheat()
    {
        List<Color> tmpColorList = new List<Color>();

        foreach (Image tmpImage in imageBarCounterList)
        {
            tmpColorList.Add(tmpImage.color);
            tmpImage.color = Color.red;
        }

        foreach (Image tmpImage in disabledImageBarCounterList)
        {
            tmpColorList.Add(tmpImage.color);
            tmpImage.color = Color.red;
        }

        yield return new WaitForSeconds(2);

        foreach (Image tmpImage in imageBarCounterList)
        {
            tmpImage.color = tmpColorList.First();
            tmpColorList.RemoveAt(0);
        }

        foreach (Image tmpImage in disabledImageBarCounterList)
        {
            tmpImage.color = tmpColorList.First();
            tmpColorList.RemoveAt(0);
        }
    }
}