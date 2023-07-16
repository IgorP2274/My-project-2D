using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Animator _animator;
    private bool _isWalking;
    private bool _isGrounded = false;
    private bool _isRight = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isGrounded = true;
    }


    void Update()
    {
        _isWalking = false;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_isRight)
            {
                Flip();
                transform.Translate(-1.5f, 0, 0);
            }

            _isWalking = true;
            transform.Translate(-1 * _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!_isRight) 
            {
                Flip();
                transform.Translate(1.5f, 0, 0);
            }

            _isWalking = true; ;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
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

    private void Flip()
    {
        _isRight = !_isRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGrounded = true;
            Debug.Log(_isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGrounded = false;
            Debug.Log(_isGrounded);
        }
    }
}
