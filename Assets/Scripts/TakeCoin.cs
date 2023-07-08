using UnityEngine;
using UnityEngine.Events;

public class TakeCoin : MonoBehaviour
{
    [SerializeField] private UnityEvent _takeCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ThisIsCoin>(out ThisIsCoin ThisIsCoin)) 
        {
            _takeCoin?.Invoke();
            Destroy(collision.gameObject);
        } 
    }
}
