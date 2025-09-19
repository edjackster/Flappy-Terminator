using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private BulletPool _bulletPool;

    public void Shoot()
    {
        var bullet = _bulletPool.GetObject();
        bullet.transform.position = _bulletSpawn.position;
        bullet.Init(_bulletSpawn.rotation, _bulletSpeed);
    }

    public void Init(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }
}
