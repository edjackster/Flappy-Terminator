using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _enemyPool.PutObject(enemy);
        }
        
        if (other.TryGetComponent(out Bullet bullet))
        {
            _bulletPool.PutObject(bullet);
        }
    }
}
