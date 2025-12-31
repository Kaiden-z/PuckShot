using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ToggleDraggable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SecondOrderDynamics2D positionDynamics;
    
    private Rigidbody2D _rb;
    private RigidbodyType2D _originalBodyType;
    private bool _isGrabbed;
    private Camera _camera;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _originalBodyType = (_rb != null) ? _rb.bodyType : RigidbodyType2D.Kinematic;
        _isGrabbed = false;
        _camera = Camera.main;
        positionDynamics = new SecondOrderDynamics2D(transform.position);
    }

    private void Update()
    {
        if (!_isGrabbed) return;
        
        Vector2 target = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float dt = Time.deltaTime;
        
        transform.position = positionDynamics.Step(dt, target);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isGrabbed = !_isGrabbed;

        if (_isGrabbed)
        {
            _originalBodyType = _rb.bodyType;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _rb.linearVelocity = Vector2.zero;
            positionDynamics.Reset(transform.position);
        }
        else
        {
            _rb.bodyType = _originalBodyType;
        }
    }
}
