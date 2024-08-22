using UnityEngine;

public class DifficultyIncreaseEvent : MonoBehaviour
{
    [SerializeField] private GameObject sxAsteroidManager;
    [SerializeField] private GameObject dxAsteroidManager;
    [SerializeField] private ScoreEvent scoreEvent;
    private float difficultyLevel;
    private int score;
    private bool firstIncrease;

    public void IncreaseDifficulty()
    {
        difficultyLevel++;
        score = scoreEvent.GetScore();
        if (score > 5000 && difficultyLevel >= 3 && !firstIncrease)
        {
            sxAsteroidManager.SetActive(true);
            dxAsteroidManager.SetActive(true);
            firstIncrease = true;
        }
    }
}
