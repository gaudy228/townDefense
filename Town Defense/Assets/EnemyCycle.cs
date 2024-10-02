using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCycle : MonoBehaviour
{
    private float _curentTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private Image _Clock;

    [SerializeField] private TextMeshProUGUI _countEnemytext;
    [SerializeField] private float _countEnemy;
    [SerializeField] private GameObject _endGame;
    
    CycleFeed _cycleFeed;
    void Start()
    {
        _cycleFeed = GetComponent<CycleFeed>();
        _curentTime = _maxTime;
        _countEnemy = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _countEnemytext .text = _countEnemy.ToString(); 
        if (_curentTime >= 0)
        {
            _curentTime -= Time.deltaTime;
            _Clock.fillAmount = _curentTime / _maxTime;
        }
        else
        {
            if(_cycleFeed._warrior - _countEnemy < 0)
            {
                _countEnemy -= _cycleFeed._warrior;
                _cycleFeed._warrior = 0;
                
                if(_cycleFeed._peasant - _countEnemy * 3 < 0)
                {
                    _cycleFeed._peasant = 0;
                    Time.timeScale = 0.0f;
                    _endGame.SetActive(true);
                }
                else
                {
                    _cycleFeed._peasant -= _countEnemy * 3;

                }
            }
            else
            {
                _cycleFeed._warrior -= _countEnemy;

            }
            
            _curentTime = _maxTime;
            _countEnemy += Random.Range(10, 15);
            
        }
    }
}
