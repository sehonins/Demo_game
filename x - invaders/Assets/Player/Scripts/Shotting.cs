using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shotting : MonoBehaviour
{
    [SerializeField]
    Weapon _weaponEqupid;
    Bullet _bulletPrefab;
    [SerializeField]
    Transform _buletPlace;
    [SerializeField]
    Text _bulleText;

    Coroutine _shotingCoroutine;
    bool _canShoot = true;

    int _bulletsMax;
    int _bulletsLeft;
    float _reloadTime;
    float _timeBetweanShoots;

    void SetUpWeapon()
    {
        if (_weaponEqupid != null)
        {
            _bulletsMax = _weaponEqupid.BulletCount;
            _bulletPrefab = _weaponEqupid.BulletPrefab;
            _reloadTime = _weaponEqupid.RelaodTime;
            _timeBetweanShoots = _weaponEqupid.TimeBetwenShoots;
        }
        else
        {
            _bulletPrefab= null;
            _reloadTime = 0;
            _bulletsMax = 30;
            _timeBetweanShoots= 0.1f;
        }
        
    }

    private void Start()
    {
        SetUpWeapon();
        _bulletsLeft = _bulletsMax;
        _bulleText.text = _bulletsLeft.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canShoot)
                Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(_shotingCoroutine!= null)
            StopCoroutine(_shotingCoroutine);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        _bulletsLeft = _bulletsMax;
        _bulleText.text = _bulletsLeft.ToString();
    }

    private void Shoot()
    {
        _shotingCoroutine = StartCoroutine(Shooting());
    }


    IEnumerator Shooting()
    {
        while (_bulletsLeft > 0)
        {
            Instantiate(_bulletPrefab, _buletPlace.transform.position, Quaternion.identity);
            _bulletsLeft--;
            _bulleText.text = _bulletsLeft.ToString();    
            yield return new WaitForSeconds(_timeBetweanShoots);
        }
    }
}
