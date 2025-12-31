using System;
using UnityEngine;

public class Mallet : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }
}
