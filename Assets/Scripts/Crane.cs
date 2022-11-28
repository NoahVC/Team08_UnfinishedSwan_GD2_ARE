using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : ValveActivatable
{
    private Rigidbody _joint;
    private float _rotation;
    private float _initialRotation;

    [SerializeField]
    private float _minRotation=0;
    [SerializeField]
    private float _maxRotation=360;

    private void Start()
    {
        _initialRotation = transform.rotation.eulerAngles.z;
        _joint = transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 temp = transform.rotation.eulerAngles;
        float change = Mathf.Clamp((_initialRotation + _rotation), _initialRotation + _minRotation, _initialRotation + _maxRotation);
        //float change = _initialRotation + _rotation;
        //Debug.Log(change);
        _joint.MoveRotation(Quaternion.Euler(temp.x, change, temp.z));
    }

    public override void Activate(float rotation)
    {
        _rotation = rotation;
    }
}
