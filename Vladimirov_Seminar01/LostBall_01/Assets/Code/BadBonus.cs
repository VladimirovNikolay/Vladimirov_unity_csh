using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class BadBonus : InteractiveObject, IFlay, IRotation
{
    private float _heightFlay;
    private float _speedRotation;
    public Transform GameObject_BadBonus;

    private void Awake()
    {
        _heightFlay = Random.Range(1.0f, 6.0f);
        _speedRotation = Random.Range(10.0f, 50.0f);
    }

    protected override void Interaction()
    {
        //
    }

    public void Flay()
    {
        GameObject_BadBonus.localPosition = new Vector3(GameObject_BadBonus.localPosition.x, 
            Mathf.PingPong(Time.time, _heightFlay), GameObject_BadBonus.localPosition.z);
    }
    public void Rotation()
    {
        GameObject_BadBonus.transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
    }

}
