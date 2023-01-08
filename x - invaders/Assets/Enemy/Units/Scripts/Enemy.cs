using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator _anim;
    int _maxHp = 2;
    int _currentHp;
    int _damage = 1;
    int _pointsForKill = 10;
    float _deadTimeAnimation = 1.5f;

    float _deadBodyScrollSpeed = .2f;


    private void Start()
    {
       _currentHp = _maxHp;
        _anim = GetComponent<Animator>();
    }
    public void GetDamage(int damage)
    {
        _currentHp -= damage;

        if(_currentHp <= 0)
        {
            GivePoints();
            DisableEnemy();
            StartCoroutine(Dead(_deadTimeAnimation));
        }

    }
  

    void GivePoints()
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if(inventory != null)
        {
            inventory.GetPoints(_pointsForKill);
        }
        
    }

    private void DisableEnemy()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<EnemyMovement>()._moveSpeed = _deadBodyScrollSpeed;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        if(_anim!= null)
        _anim.Play("Goblin_deadAnimation");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.GetDamage(_damage);

        if (collision.gameObject.TryGetComponent(out Vilage vilage))
        {
            vilage.GetDamage(_damage);
            Destroy(gameObject);
        }
            
    }

    IEnumerator Dead(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
