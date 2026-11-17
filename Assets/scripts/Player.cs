using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField]
    private string _horizontalAxis = "Horizontal";
    [SerializeField]
    private string _verticalAxis = "Vertical";
    [SerializeField]
    private Rigidbody2D _rb2d;

    private Vector2 _input;

    [SerializeField]
    private float _speed = 3f;

    public UnityEvent OnPlayerDie;

    private void FixedUpdate()
    {
        _rb2d.linearVelocity = _input * _speed;
    }

    // Update is called once per frame  
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        float verticalInput = Input.GetAxisRaw(_verticalAxis);
        _input = new Vector2(horizontalInput, verticalInput);
        _input.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMove>() == null) return;

        Die();
    }

    public void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
}
