using System.Collections;
using UnityEngine;
using TMPro;


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
        while (text.maxVisibleCharacters < text.textInfo.characterCount)
        {
            text.maxVisibleCharacters++;
            yield return new WaitForSeconds(delay);
        }
    }
}