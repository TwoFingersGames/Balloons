using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntieTheBall : MonoBehaviour
{
    private HingeJoint2D[] _joints;

    private void Awake()
    {
        _joints = gameObject.GetComponentsInChildren<HingeJoint2D>();
    }
    private void OnMouseDown()
    {
        Untie();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.TryGetComponent(out Blade blade))
        {
            Untie();
        }
    }
    private void Untie()
    {
        transform.DetachChildren();
        foreach (var joint in _joints)
        {
            joint.enabled = false;
        }
    }
}
