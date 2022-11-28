using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    /*private void onTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vines")
        {
            collision.gameObject.GetComponent<IActivatable>().Activate();
            Debug.Log(collision.gameObject.tag);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vines")
        {
            other.gameObject.GetComponent<IActivatable>().Activate();
            Debug.Log(other.gameObject.tag);
        }
    }
}
