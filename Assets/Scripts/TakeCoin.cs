using UnityEngine;
using UnityEngine.Events;

public class TakeCoin : MonoBehaviour
{
    [SerializeField] private UnityEvent _takeCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin thisIsCoin))
        {
            _takeCoin?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
