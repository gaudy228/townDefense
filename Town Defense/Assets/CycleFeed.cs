using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private bool _isPlusW = false;
    private bool _isPlusP = false;

     private float _timerPlusW;
     private float _timerPlusP;
    [SerializeField] private Image _ClockPlusW;
    [SerializeField] private Image _ClockPlusP;

    [SerializeField] private float _maxTimerPlus;

    [SerializeField] private Button _addWarrior;
    [SerializeField] private Button _addPeasant;

    void Start()
    {
        _cycleWheat = GetComponent<CycleWheat>();
        _curentTime = _maxTime;
        _timerPlusW = _maxTimerPlus;
        _timerPlusP = _maxTimerPlus;
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
            if(_cycleWheat._wheat - _countFeed < 0)
            {
                _cycleWheat._wheat = 0;
            }
            else
            {
                _cycleWheat._wheat -= _countFeed;

            }
            
            _curentTime = _maxTime;
        }

        UpdatePlusP();
        UpdatePlusW();



       


        _countPeasantText.text = "Крестьяне: " + _peasant.ToString();
        _countWarriorText.text = "Воинов: " + _warrior.ToString();
    }
    public void PlusWarrior()
    {
        if(_cycleWheat._wheat - _countFeedWarrior >= 0 && !_isPlusW)
        {
            //_warrior++;
            _isPlusW = true;
            _cycleWheat._wheat -= _countFeedWarrior;
            _addWarrior.interactable = false;
        } 
    }
    public void PlusPeasant()
    {
        if (_cycleWheat._wheat - _countFeedPeasant >= 0 && !_isPlusP)
        {
            //_peasant++;
            _isPlusP = true;
            _cycleWheat._wheat -= _countFeedPeasant;
            _addPeasant.interactable = false;
        }
    }

    private void UpdatePlusW()
    {
        if (_isPlusW && _timerPlusW >= 0)
        {
            _timerPlusW -= Time.deltaTime;
            
        }
        else if(_isPlusW && _timerPlusW <= 0)
        {
            _isPlusW = false;
            _timerPlusW = _maxTimerPlus; 
            _warrior++;
            _addWarrior.interactable = true;
        }
        _ClockPlusW.fillAmount = _timerPlusW / _maxTimerPlus;

    }
    private void UpdatePlusP()
    { 
        if (_isPlusP && _timerPlusP >= 0)
        {
            _timerPlusP -= Time.deltaTime;
            

        }
        else if (_isPlusP && _timerPlusP <= 0)
        {
            _isPlusP = false;
            _timerPlusP = _maxTimerPlus;
            _peasant++;
            _addPeasant.interactable = true;
        }
        _countFeed = _countFeedWarrior * _warrior;

        
        _ClockPlusP.fillAmount = _timerPlusP / _maxTimerPlus;

    }
}
