using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private int bulletNumber = 20;
    [SerializeField] private float bulletKillHeight;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private GameObject starship;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<Bullet> bulletPool;
    [SerializeField] private List<Bullet> activeBullet;
    [SerializeField] private SpawnableEvent ammunitionUsed;
    [SerializeField] private SpawnableEvent ammunitionReloaded;
    [SerializeField] private SpawnableEvent overheat;
    private PlayerInput input;
    private Queue<Bullet> inactiveBullet;
    private bool isDead;
    private bool delay;
    private bool canShoot;

    private void Start()
    {
        inactiveBullet = new Queue<Bullet>();

        for (int i = 0; i < bulletNumber; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
            inactiveBullet.Enqueue(bullet);
            ammunitionReloaded.Invoke();
        }

        input = FindObjectOfType<PlayerInput>();
        input.actions["Fire"].started += OnFireStarted;
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        if (delay == false && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (inactiveBullet.TryDequeue(out Bullet bullet) && !isDead && Time.timeScale != 0)
        {
            bullet.transform.position = starship.transform.position;
            bullet.gameObject.SetActive(true);
            activeBullet.Add(bullet);
            audioSource.PlayOneShot(shootClip);
            ammunitionUsed.Invoke();
        }
        else
        {
            delay = true;
            StartCoroutine(ReloadTime());
        }
    }

    private void Update()
    {
        List<Bullet> toRemove = new List<Bullet>();

        foreach (Bullet bullet in activeBullet)
        {
            if (bullet.transform.position.y >= bulletKillHeight || bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.SetActive(false);
                inactiveBullet.Enqueue(bullet);
                toRemove.Add(bullet);
            }
        }

        foreach (Bullet removeObject in toRemove)
        {
            activeBullet.Remove(removeObject);
            ammunitionReloaded.Invoke();
        }
    }

    private IEnumerator ReloadTime()
    {
        overheat.Invoke();
        yield return new WaitForSeconds(2);
        delay = false;
    }

    public void SetDeath()
    {
        isDead = true;
        input.actions["Fire"].started -= OnFireStarted;
    }

    public void CanShoot(bool tmp)
    {
        canShoot = tmp;
    }
}