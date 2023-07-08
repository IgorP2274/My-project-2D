using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRespawn : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _respawnTime;

    private void Start()
    {
        StartCoroutine(Create());
    }

    public void StartCreation()
    {
            StartCoroutine(Create());
    }

    public IEnumerator Create()
    {
        while (true)
        {
            Vector3 vector3 = transform.position;
            GameObject coin = Instantiate(_coin, vector3, Quaternion.identity);
            coin.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 10) * 20);
            yield return new WaitForSeconds(_respawnTime);
        }
    }
}
