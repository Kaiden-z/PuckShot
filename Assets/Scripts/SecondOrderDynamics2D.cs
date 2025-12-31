
using System;
using UnityEngine;

[Serializable]
public class SecondOrderDynamics2D
{
    [SerializeField] private float frequency = 1f;
    [SerializeField] private float damping = 0.5f;
    [SerializeField] private float stiffness = 2f;
    
    private Vector2 _xp;
    private Vector2 _y;
    private Vector2 _yd;
    
    private float _k1;
    private float _k2;
    private float _k3;

    public SecondOrderDynamics2D(Vector2 x0)
    {
        _k1 = damping / (Mathf.PI * frequency);
        _k2 = 1 / Mathf.Pow(2 * Mathf.PI * frequency, 2);
        _k3 = stiffness * damping / (2 * Mathf.PI * frequency);

        _xp = x0;
        _y = x0;
        _yd = Vector2.zero;
        
        Reset(x0);
    }

    public Vector2 Step(float T, Vector2 x)
    {
        Vector2 xd = (x - _xp) / T;
        _xp = x;
        _y += T * _yd;
        _yd += T * (x + _k3 * xd - _y - _k1 * _yd) / _k2;
        return _y;
    }

    public void Reset(Vector2 x)
    {
        _xp = x;
        _y = x;
        _yd = Vector2.zero;
    }
}
