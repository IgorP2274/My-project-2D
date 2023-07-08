using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private int _coinCount = 0;

    public void AddCoin()
    {
        _coinCount++;
        GetComponent<Text>().text = "Монетки: " + _coinCount;
    }
}
