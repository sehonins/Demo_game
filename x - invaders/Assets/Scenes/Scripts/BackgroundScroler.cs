using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroler : MonoBehaviour
{
    float _scrollSpeed = .1f;
    Material _material;
    Vector2 _offset;

    private void Start()
    {
        _material= GetComponent<Renderer>().material;
        _offset = new Vector2(0, _scrollSpeed);
    }

    private void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime; 
    }
}
