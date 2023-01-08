using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Camera _cam;
    float _xMin,_xMax,_yMin,_yMax;
    float _padding = .15f;

    float _moveSpeed = 2.5f;
    void Start()
    {
        SetUpBorders();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        float xMove = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        var xPos = Mathf.Clamp(transform.position.x + xMove, _xMin, _xMax);
        var yPos = Mathf.Clamp(transform.position.y + yMove, _yMin, _yMax);

        transform.position = new Vector3(xPos, yPos, transform.position.z) ;
    }

    void SetUpBorders()
    {
        if (_cam == null)
            _cam = Camera.main;
        _xMin = _cam.ViewportToWorldPoint(new Vector3(0 + _padding, 0, 0)).x;
        _xMax = _cam.ViewportToWorldPoint(new Vector3(1 - _padding, 0, 0)).x;
        _yMin = _cam.ViewportToWorldPoint(new Vector3(0, 0 + _padding, 0)).y;
        _yMax = _cam.ViewportToWorldPoint(new Vector3(0, .5f, 0)).y;
    }
}
