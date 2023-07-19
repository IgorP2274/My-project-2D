using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class CoinCounter : MonoBehaviour
{
    private int _coinCount = 0;
    private Text _text;

    private void Start()
        => _text = GetComponent<Text>();

    public void AddCoin()
    {
        _coinCount++;
        _text.text = "Монетки: " + _coinCount;
    }
}
