using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CycleFeed : MonoBehaviour
{
     private float _curentTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _Clock;

     private float _countFeed;
    [SerializeField] private float _countFeedWarrior;
    [SerializeField] public float _countFeedPeasant;


    CycleWheat _cycleWheat;

    [HideInInspector] public float _peasant;
    [SerializeField] private TextMeshProUGUI _countPeasantText;

    [HideInInspector] public float _warrior;
    [SerializeField] private TextMeshProUGUI _countWarriorText;
    void Start()
    {
        _cycleWheat = GetComponent<CycleWheat>();
        _curentTime = _maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_curentTime >= 0)
        {
            _curentTime -= Time.deltaTime;
            _Clock.fillAmount = _curentTime / _maxTime;
        }
        else
        {
            
            _cycleWheat._wheat -= _countFeed;
            _curentTime = _maxTime;
        }
        
        _countFeed = _countFeedWarrior * _warrior;


        _countPeasantText.text = "Крестьяне: " + _peasant.ToString();
        _countWarriorText.text = "Воинов: " + _warrior.ToString();
    }
    public void PlusWarrior()
    {
        if(_cycleWheat._wheat > 0)
        {
            _warrior++;
            _cycleWheat._wheat -= _countFeedWarrior;
        } 
    }
    public void PlusPeasant()
    {
        if (_cycleWheat._wheat > 0)
        {
            _peasant++;
            _cycleWheat._wheat -= _countFeedPeasant;
        }
    }
}
