using System.Collections;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private SpawnableEvent difficultyEvent;

    private void Start()
    {
        StartCoroutine(IncreaseDifficulty());
    }
    
    private IEnumerator IncreaseDifficulty()
    {
        difficultyEvent.Invoke();
        yield return new WaitForSeconds(30);
        StartCoroutine(IncreaseDifficulty());
    }
}
