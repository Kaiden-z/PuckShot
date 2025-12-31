using UnityEngine;

public class BumpSlide : MonoBehaviour
{
    [SerializeField] public float bumpForce = 1f;
    

    private Rigidbody2D _rb;
    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = Vector2.Normalize(transform.position - collision.transform.position);
        
        _rb.AddForce(direction * bumpForce, ForceMode2D.Impulse);
    }
}
