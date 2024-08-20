using UnityEngine;

public class AsteroidChildren : MonoBehaviour
{
    [SerializeField] private string targetTag = "Bullet";
    [SerializeField] private GameObject[] powerUpPrefabs;
    [SerializeField] private Asteroid asteroid;
    [SerializeField] private SpawnableEvent audioCollision;
    [SerializeField] private SpawnableEvent audioDestroy;
    private GameObject scoreEvent;
    private int totalHp;
    private int hp;


    public void Init(int i)
    {
        totalHp = i;
        hp = i;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            hp--;
            this.audioCollision.Invoke();
            if (hp <= 0)
            {
                this.audioDestroy.Invoke();
                gameObject.SetActive(false);
                scoreEvent = GameObject.Find("Score Event");
                scoreEvent.GetComponent<ScoreEvent>().AddScore(25 * totalHp);
                if (powerUpPrefabs.Length != 0 && Random.Range(0, 4) < 2)
                {
                    Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], gameObject.transform.position, Quaternion.identity);
                }
            }
        }
    }
}