using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using System.Runtime.CompilerServices;


public class TextScript : MonoBehaviour // componente della scritta "instructions" per fare l'effetto typewriter.
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float delay;
    [SerializeField] private float startWriting;

    private int maxCharacters;


    private void Start()
    {
        text.maxVisibleCharacters = 0;
        StartCoroutine(StartWriting());
    }

    private IEnumerator StartWriting()
    {
        yield return new WaitForSeconds(startWriting);
        text.gameObject.SetActive(true);
        StartCoroutine(TypewriterEffect());
    }

    private IEnumerator TypewriterEffect()
    {
        while (text.maxVisibleCharacters < text.ToString().Length + 1)
        {
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(delay);
        }
    }
}