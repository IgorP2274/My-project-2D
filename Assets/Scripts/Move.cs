using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isWalking;
    private bool _isGrounded = false;
    private bool _isRight = false;
    private float _directionLeft;
    private float _directionRight;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _isGrounded = true;
        _directionLeft = -1.5f;
        _directionRight = 1.5f;
    }

    private void Update()
    {
        _isWalking = false;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_isRight)
                Flip(_directionLeft);

            Walk(_directionLeft);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!_isRight) 
                Flip(_directionRight);

            Walk(_directionRight);
        }

        if (_isGrounded && _isWalking)
            _animator.SetFloat("Speed", 1);
        else
            _animator.SetFloat("Speed", 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * 100 * _jumpForse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = false;
    }

    private void Walk(float direction)
    {
        _isWalking = true;
        transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
    }

    private void Flip(float direction)
    {
        _isRight = !_isRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        transform.Translate(direction, 0, 0);
    }
}
