using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    [Header("InteractiveThisCar")] [SerializeField]
    private CarInteractive _interactiveTrunk = null;
    [Header("DebugField")] [SerializeField]
    private bool _engine;

    [SerializeField] private bool _rides, _openDoor, _openT, _openH;

    [Header("MainSettings")] [SerializeField]
    private float _speed = 10;

    [SerializeField] private List<Transform> _doors = new List<Transform>();

    [SerializeField] private Transform _hood, _trunk;
    [SerializeField] private float _maxAngelD = 80f; //Door Y
    [SerializeField] private float _angelH = 60f, _angelT = -125f; //Hood & Trunk X

    [SerializeField] private float _openTime = 0.5f, _closeTime = 0.25f;

    private void Start()
    {
        _interactiveTrunk.Interactive += OpenTrunk;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EngineControl();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenHood();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OpenTrunk();
        }
    }

    private void EngineControl()
    {
        _engine = !_engine;
    }

    private void OpenDoor()
    {
        _openDoor = !_openDoor;

        if (_openDoor)
        {
            for (int i = 0; i < _doors.Count; i++)
            {
                if (i % 2 == 0)
                {
                    _doors[i].DOLocalRotateQuaternion(Quaternion.Euler(0, _maxAngelD, 0), _openTime);
                }
                else
                {
                    _doors[i].DOLocalRotateQuaternion(Quaternion.Euler(0, -_maxAngelD, 0), _openTime);
                }
            }
        }
        else
        {
            for (int i = 0; i < _doors.Count; i++)
            {
                _doors[i].DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), _closeTime);
            }
        }
    }

    private void OpenHood()
    {
        _openH = !_openH;

        if (_openH)
        {
            _hood.DOLocalRotateQuaternion(Quaternion.Euler(_angelH, 0, 0), _openTime);
        }
        else
        {
            _hood.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), _closeTime);
        }
    }

    private void OpenTrunk()
    {
        _openT = !_openT;

        if (_openT)
        {
            _trunk.DOLocalRotateQuaternion(Quaternion.Euler(_angelT, 0, 0), _openTime);
        }
        else
        {
            _trunk.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), _closeTime);
        }
    }
}