using UnityEngine;

public class PowerUpEvent : MonoBehaviour
{
    [SerializeField] private float destroyDelay;
    [SerializeField] private GameObject destructionVFX;
    private bool pickedUp;

    private void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickedUp = true;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!pickedUp)
        {
            Destroy(Instantiate(destructionVFX, transform.position, Quaternion.identity), 2);
        }
    }
}