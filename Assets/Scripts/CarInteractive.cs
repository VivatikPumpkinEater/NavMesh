using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteractive : MonoBehaviour
{
    public System.Action Interactive;

    private Player _player = null;

    private void OnMouseDown()
    {
        Debug.Log("Click");
        if (_player != null)
        {
            Debug.Log(Vector3.Distance(_player.transform.position, transform.position));
            if (Vector3.Distance(_player.transform.position, transform.position) < 1.5f)
            {
                Interactive?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Player>())
        {
            _player = col.gameObject.GetComponent<Player>();
        }
    }
}