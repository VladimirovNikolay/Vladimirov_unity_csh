using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class InteractiveObject : MonoBehaviour
{
    protected Color _color;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Interaction();
        Destroy(gameObject);
    }
    protected abstract void Interaction();

    private void Start()
    {
        Action();
    }
    public void Action()
    {
        _color = Random.ColorHSV();
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = _color;
        }
    }
}
