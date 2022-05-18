﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamResize : MonoBehaviour
{
  [SerializeField] private Vector2 _refResolution;

    private void Start()
    {
        float refAspect = _refResolution.x / _refResolution.y;
        float scaleMultiplier = refAspect / Camera.main.aspect;
        float newSize = Camera.main.fieldOfView * scaleMultiplier;

        Camera.main.fieldOfView = newSize;
    }
}
