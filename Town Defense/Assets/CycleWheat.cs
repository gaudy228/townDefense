using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CycleWheat : MonoBehaviour
{
    private float _curentTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _Clock;

    public float _wheat;
    [SerializeField] private float _plusWheat;
    [SerializeField] private TextMeshProUGUI _countWheat;
    [SerializeField] private float _multiplPeasant;
    CycleFeed cycleFeed;
    void Start()
    {
        cycleFeed = GetComponent<CycleFeed>();
        _curentTime = _maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(_curentTime >= 0)
        {
            _curentTime -= Time.deltaTime;
            _Clock.fillAmount = _curentTime / _maxTime;
        }
        else
        {
            _wheat += _plusWheat + _multiplPeasant * cycleFeed._peasant;
            _curentTime = _maxTime;
        }
        _countWheat.text = "ѕшеница: " + _wheat.ToString();
    }
}
