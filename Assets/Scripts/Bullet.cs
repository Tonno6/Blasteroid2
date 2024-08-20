using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string targetTag = "Enemy";
    [SerializeField] private GameObject vfx;

    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(Instantiate(vfx, transform.position, Quaternion.identity), 2);
            gameObject.SetActive(false);
        }
    }
}
