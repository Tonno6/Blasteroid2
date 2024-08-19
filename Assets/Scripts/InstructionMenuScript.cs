using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionMenuScript : MonoBehaviour // Mi gestisce come compare in scena il pannello delle istruzioni, prima faccio comprare il titolo 
    // "Instructions" con l'effetto typewriter (che ha uno script apposta chiamato "textScript" e poi faccio comprare il contenuto stesso con le istruzioni.
{
    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private GameObject instructionInfo;
    [SerializeField] private float activateInstructionInfo;
    [SerializeField] private SpawnableEvent instructionMenuEnd;
    private PlayerInput input;

    private void Start()
    {
        StartCoroutine(ActivateInstructionInfo());
        input = FindObjectOfType<PlayerInput>();
        input.actions["Instruction"].started += OnInstructionEnd;
    }

    private void OnInstructionEnd(InputAction.CallbackContext context)
    {
        instructionMenuEnd.Invoke();
    }
    
    private IEnumerator ActivateInstructionInfo()
    {
        yield return new WaitForSeconds(activateInstructionInfo);
        instructionInfo.SetActive(true);
    }
}
