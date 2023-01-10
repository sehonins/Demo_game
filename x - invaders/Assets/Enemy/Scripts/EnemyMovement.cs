using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    WaveConfig _waveConfig;
    List<Transform> _waypoints = new();
    int _waypointIndex = 0;
    public float _moveSpeed = 2f;


    void Start()
    {
        if(_waveConfig != null)
        {
            _moveSpeed = _waveConfig.GetMoveSpeed();
            _waypoints = _waveConfig.GetWayPoints();
            transform.position = _waypoints[_waypointIndex].transform.position;
        }
        
    }

    public void SetUpWaveConfig(WaveConfig waveConfig)
    {
        _waveConfig= waveConfig;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_waypointIndex <= _waypoints.Count - 1)
        {
            var targetPos = _waypoints[_waypointIndex].transform.position;
            var movement = _moveSpeed * Time.deltaTime;

            transform.position =
                Vector2.MoveTowards(transform.position, targetPos, movement);

            if (transform.position == targetPos)
            {
                _waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
