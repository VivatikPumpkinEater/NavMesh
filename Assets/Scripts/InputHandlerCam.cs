using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerCam : MonoBehaviour
{
    [SerializeField] private float _sens = 50f;

    private Vector2 _touchBegan, _deltaTouch;

    private Quaternion _startCamPos;

    private void Start()
    {
        _startCamPos = transform.rotation;
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                _touchBegan = t.position;
            }

            if (t.phase == TouchPhase.Moved)
            {
                _deltaTouch = t.position - _touchBegan;
                _deltaTouch.Normalize();


                Quaternion Yqua = Quaternion.AngleAxis(_deltaTouch.x * _sens * Time.deltaTime, Vector3.up);
                transform.rotation = _startCamPos * Yqua;
                _startCamPos = transform.rotation;
            }
        }
    }
}