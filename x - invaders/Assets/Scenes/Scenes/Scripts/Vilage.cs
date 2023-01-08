using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vilage : MonoBehaviour
{
    [SerializeField]
    Slider _hpBar;
    int _maxHP = 5;
    int _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
        SetUpHPBar();
    }

    private void OnGameOver()
    {
        print("You lost");
    }

    public void GetDamage(int damage)
    {
        _currentHP -= damage;
        _hpBar.value = _currentHP;
        if (_currentHP <= 0)
        {
            _currentHP = 0;
            OnGameOver();
        }
      
    }
    
    private void SetUpHPBar()
    {
        if(_hpBar == null)
        {
            _hpBar = GetComponentInChildren<Slider>();
        }
        _hpBar.maxValue = _currentHP;
        _hpBar.value = _hpBar.maxValue;
    }

}
