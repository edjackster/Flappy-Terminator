using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 2f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay( transform.position, transform.right);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (_speed * Time.deltaTime));
    }

    public void Init(Quaternion rotation, float speed)
    {
        transform.rotation = rotation;
        _speed = speed;
    }
}
