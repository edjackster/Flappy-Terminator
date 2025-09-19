using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler),  typeof(Shooter))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _shootingDelay;
    
    private Shooter _shooter;
    private CollisionHandler _handler;
    
    public event Action<Enemy> Died;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
        _shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
        StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Init(BulletPool bulletPool)
    {
        _shooter.Init(bulletPool);
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Bullet)
        {
            Died?.Invoke(this);
        }
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_shootingDelay);

        while (enabled)
        {
            yield return wait;
            _shooter.Shoot();
        }
    }
}
