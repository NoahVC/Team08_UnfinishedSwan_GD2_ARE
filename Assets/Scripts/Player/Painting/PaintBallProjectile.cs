using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaintBallProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject PaintDecalPrefab;
    [SerializeField]
    private Rigidbody _rigidbody;


    public Transform DecalsParent;
    public Color paintColor;

    private void OnCollisionEnter(Collision collision) //TO DO: Add painting application logic (most likely here) and interaction with world depending on the tags
    {
        if(collision.gameObject.tag != "Paintball" && collision.gameObject.tag != "Player") //Paint ball disappears when hitting anything but another paint ball or the player.
        {
            Vector3 _normal = collision.contacts[0].normal;
            Vector3 _vel = _rigidbody.velocity;
            Instantiate(PaintDecalPrefab, this.transform.position, Quaternion.LookRotation(_vel, _normal));
            Destroy(gameObject);
            //Paint();
        }
    }
}
