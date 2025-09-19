using System;
using UnityEngine;

public class PlaneInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    public event Action Tapped;
    public event Action Shoot;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            Tapped?.Invoke();
        
        if (Input.GetMouseButtonDown(RightMouseButton))
            Shoot?.Invoke();
    }
}
