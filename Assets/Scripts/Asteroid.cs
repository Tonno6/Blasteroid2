using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Vector2 fallSpeedRange;
    [SerializeField] private Vector2 sizeRange;
    [SerializeField] private float tumble;
    [SerializeField] private int hp = 1;
    [SerializeField] private float difficultyLevel;
    [SerializeField] private AsteroidChildren children;
    private float fallSpeed;
    private float size;

    public void Init(float tmpDifficultyLevel)
    {
        SetDifficultyLevel(tmpDifficultyLevel);
        SetFallingSpeed();
        SetHp();
        children.Init(hp);
    }

    private void Start()
    {
        GetComponentInChildren<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    private void Update()
    {
        transform.Translate(0, fallSpeed * Time.deltaTime, 0);
    }

    private void SetDifficultyLevel(float tmpDifficultyLevel)
    {
        difficultyLevel = tmpDifficultyLevel;
    }

    private void SetFallingSpeed()
    {
        fallSpeed = -Random.Range(fallSpeedRange.x, fallSpeedRange.y);
        size = Random.Range(sizeRange.x, sizeRange.y);
        transform.localScale = new Vector3(size, size, size);
    }

    private void SetHp()
    {
        hp = (int)((size * 2) + difficultyLevel);
        if (hp >= 10)
        {
            hp = 10;
        }
    }
}