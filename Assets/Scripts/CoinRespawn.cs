using System.Collections;
using UnityEngine;

public class CoinRespawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _respawnTime;
    [SerializeField] private int _coinCount;

    private int _randomLeftForseMax;
    private int _randomRightForseMax;
    private int _UpForse;
    private int _totalForse;
    private WaitForSeconds _wait;

    private void Start()
    {
        _randomLeftForseMax = -3;
        _randomRightForseMax = 3;
        _UpForse = 10;
        _totalForse = 20;
        _wait = new WaitForSeconds(_respawnTime);

        StartCoroutine(Create());
    }

    public IEnumerator Create()
    {
        for (int i = 0; i < _coinCount; i++)
        {
            Vector3 vector3 = transform.position;
            Coin coin = Instantiate(_coin, vector3, Quaternion.identity);
            coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(_randomLeftForseMax, _randomRightForseMax), _UpForse) * _totalForse);
            yield return _wait;
        }
    }
}
