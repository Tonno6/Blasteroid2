using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using System.Runtime.CompilerServices;


public class TextScript : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] float delay;
    [SerializeField] float startWriting;

    private int maxCharacters;
    private int currentCharacter;


    private void Start()
    {
        currentCharacter = 0;
        text.maxVisibleCharacters = 0;
        StartCoroutine(StartWriting());
    }

    private IEnumerator StartWriting()
    {
        yield return new WaitForSeconds(startWriting);
        text.gameObject.SetActive(true);
        StartCoroutine(TyperwriterEffect());
        
    }
    
    private IEnumerator TyperwriterEffect()
    {
        
        while (text.maxVisibleCharacters < text.ToString().Length + 1)
        {
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(delay);
        }

    }


}
