using System;
using UnityEngine;

[RequireComponent(typeof(PlaneMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(PlaneInput))]
public class Plane : MonoBehaviour
{
    private PlaneInput _input;
    private PlaneMover _planeMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _handler;
    private Shooter _shooter;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<CollisionHandler>();
        _planeMover = GetComponent<PlaneMover>();
        _shooter = GetComponent<Shooter>();
        _input = GetComponent<PlaneInput>();
    }

    private void OnEnable()
    {
        _input.Tapped += _planeMover.Tap;
        _input.Shoot += _shooter.Shoot;
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _input.Tapped -= _planeMover.Tap;
        _input.Shoot -= _shooter.Shoot;
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Obstacle or Bullet or Enemy)
        {
            GameOver?.Invoke();
        }

        else if(interactable is ScoreZone) 
        {
            _scoreCounter.Add();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _planeMover.Reset();
    }
}
