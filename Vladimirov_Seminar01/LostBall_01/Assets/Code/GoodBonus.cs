﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
{
    public Material _material;
    public Transform GameObject_GodBonus;
    private float _heightFlay;
    public Move_ball _move;
    int i = 0;

    private void Awake()
    {
        _heightFlay = Random.Range(1f, 6f);
        _material = GetComponent<Renderer>().material;
    }
    protected override void Interaction()
    {
        i = Random.Range(1, 2);
        if (i == 1)
        {
            _move.speed = 15f;
        }
        else
        {
            _move.jumpSpeed = 20f;
        }
            //throw new System.NotImplementedException();
    }
    public void Flay()
    {
        GameObject_GodBonus.localPosition = new Vector3(GameObject_GodBonus.localPosition.x, 
        Mathf.PingPong(Time.time, _heightFlay), GameObject_GodBonus.localPosition.z);
    }
    public void Flicker()
    {
        _material.color = new Color(_material.color.r, _material.color.g, 
        _material.color.b, Mathf.PingPong(Time.time, 10.0f));
    }
        
}
