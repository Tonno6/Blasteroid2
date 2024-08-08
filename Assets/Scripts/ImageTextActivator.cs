using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageTextActivator : MonoBehaviour
{
    [SerializeField] private List<Image> imageList;
    [SerializeField] private List<TMP_Text> textList;

    public List<Image> ImageList
    {
        set => imageList = value;
    }

    public List<TMP_Text> TextList
    {
        set => textList = value;
    }
    
    public void ActivateList(bool tmp)
    {
        if (tmp)
        {
            foreach (Image tmpImage in imageList)
            {
                tmpImage.GetComponent<Image>().enabled = true;
            }

            foreach (TMP_Text tmpText in textList)
            {
                tmpText.GetComponent<TMP_Text>().enabled = true;
            }
        }
        else
        {
            foreach (Image tmpImage in imageList)
            {
                tmpImage.GetComponent<Image>().enabled = false;
            }

            foreach (TMP_Text tmpText in textList)
            {
                tmpText.GetComponent<TMP_Text>().enabled = false;
            }
        }
    }
}