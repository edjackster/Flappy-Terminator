using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 2f;
    
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay( transform.position, transform.right);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * (_speed * Time.deltaTime));
    }

    public void Init(Quaternion rotation, float speed, LayerMask layerMask)
    {
        transform.rotation = rotation;
        _collider.contactCaptureLayers = layerMask;
        _speed = speed;
    }
}
