using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ScoreCounter _score;

    public override Enemy GetObject()
    {
        var enemy = base.GetObject();
        enemy.Died += OnEnemyDied;
        enemy.Init(_bulletPool);
        return enemy;
    }

    public override void PutObject(Enemy enemy)
    {
        base.PutObject(enemy);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _score.Add();
        PutObject(enemy);
    }
}