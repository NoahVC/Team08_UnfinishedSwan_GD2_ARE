using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PaintSplash : MonoBehaviour
{
    [SerializeField]
    private float _timer = 5;

    private bool _deathStart = false;
    [SerializeField]
    private Vector3 _minScale;
    private Vector3 _maxScale;
    [SerializeField]
    private float _speed = 2f;
    private float _duration = 5f;
    private float i;
    private float _rate;

    private void Start()
    {
        i = 0.0f;
        _rate = (1.0f / _duration) * _speed;
        _maxScale = transform.localScale;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            //Debug.Log("Tick tock " + _timer);
        }
        if (_timer <= 0)
            _deathStart = true;
        if (_deathStart)
        {
            i += Time.deltaTime * _rate;
            gameObject.transform.localScale = Vector3.Lerp(_maxScale, _minScale, i);
        }
        if (gameObject.transform.localScale == _minScale)
            Destroy(gameObject);
            
    }
}

