using System;
using System.Collections.Generic;
using UnityEngine;

public class Vines : MonoBehaviour, IActivatable
{
    [SerializeField]
    private List<GameObject> _vineList;
    private bool _isActivated;

    public bool isActivated
    {
        get { return _isActivated; }
        set { _isActivated = value; }
    }

    [SerializeField]
    private float _timeAdded = 1;
    [SerializeField]
    private float _growthSpeed = 1;

    [SerializeField]
    private float _initialSizeReduction = 0;

    [SerializeField]
    private float _initialTimer = 10000;
    private float _growthTimer;

    //public bool _isFirst = false;
    // public bool _isActivated = false;

    private Vector3 _fullExtendPosition;
    private Vector3 _fullExtendScale;

    private void Awake()
    {
        _growthTimer = _initialTimer;

        _fullExtendPosition = transform.position;
        _fullExtendScale = transform.localScale;

        transform.position = _fullExtendPosition + (-transform.forward * _fullExtendScale.z / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, _initialSizeReduction);

        //to make vines invisible as long as they are not growing
        if (!_isActivated)
            foreach (GameObject item in _vineList)
                item.GetComponent<MeshRenderer>().enabled = false;

    }

    void Update()
    {
        if (_growthTimer > 0 && _isActivated && transform.localScale.z <= _fullExtendScale.z)
        {
            _growthTimer -= Time.deltaTime;

            Vector3 tempSize = transform.localScale;

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (_growthSpeed * Time.deltaTime));


            // ended position - (full scale - scale)
            transform.position = _fullExtendPosition + (-(_fullExtendScale.z - transform.localScale.z) * transform.forward) / 2;


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Vines")
        {
            if (obj.GetComponent<Vines>()._isActivated == true)
            {
                _isActivated = true;
                foreach (GameObject item in _vineList)
                    item.GetComponent<MeshRenderer>().enabled = true;
            }
        }


    }

    //public void ApplyWater()
    //{
    //    if (_isActivated)
    //        _growthTimer += _timeAdded;

    //}

    public void Activate()//called by the water ballon when splashing
    {
        _growthTimer += _timeAdded;
    }

}
