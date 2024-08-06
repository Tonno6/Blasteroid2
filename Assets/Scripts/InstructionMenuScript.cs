using System.Collections;
using TMPro;
using UnityEngine;

public class InstructionMenuScript : MonoBehaviour // Mi gestisce come compare in scena il pannello delle istruzioni, prima faccio comprare il titolo 
    // "Instructions" con l'effetto typewriter (che ha uno script apposta chiamato "textScript" e poi faccio comprare il contenuto stesso con le istruzioni.
{
    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private GameObject instructionInfo;
    [SerializeField] private float activateInstructionInfo;

    private void Start()
    {
        StartCoroutine(ActivateInstructionInfo());
    }

    private IEnumerator ActivateInstructionInfo()
    {
        yield return new WaitForSeconds(activateInstructionInfo);
        instructionInfo.SetActive(true);
    }

}
