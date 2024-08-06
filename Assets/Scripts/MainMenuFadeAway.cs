using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFadeAway : MonoBehaviour
{
    [SerializeField] private List<Image> imageList;
    [SerializeField] private TMP_Text instructionsText;
    private float tmpColor;

    private void Start()
    {
        StartFadeIn();
    }

    public void StartFadeAway()
    {
        Time.timeScale = 1;
        tmpColor = 1.05f;
        StartCoroutine(FadeAway());
    }

    public void StartFadeIn()
    {
        Time.timeScale = 1;
        tmpColor = -0.05f;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeAway()
    {
        tmpColor -= 0.05f;
        foreach (Image tmpImage in imageList)
        {
            tmpImage.color = new Color(tmpImage.color.r, tmpImage.color.g, tmpImage.color.b, tmpColor);
        }
        yield return new WaitForSeconds(0.03f);
        if (tmpColor >= 0)
        {
            StartCoroutine(FadeAway());
        }
    }

    IEnumerator FadeIn()
    {
        tmpColor += 0.05f;
        foreach (Image tmpImage in imageList)
        {
            tmpImage.color = new Color(tmpImage.color.r, tmpImage.color.g, tmpImage.color.b, tmpColor);
        }
        instructionsText.color = new Color(instructionsText.color.r, instructionsText.color.g, instructionsText.color.b, tmpColor);
        yield return new WaitForSeconds(0.03f);
        if (tmpColor <= 1)
        {
            StartCoroutine(FadeIn());
        }
    }
}