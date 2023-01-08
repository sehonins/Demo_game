using UnityEngine;

public class Player : MonoBehaviour
{
    int _maxHP = 1;
    int _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void GetDamage(int damage)
    {
        _currentHP -= damage;
        if(_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

