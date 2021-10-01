using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenDestroyer : MonoBehaviour
{
    [SerializeField] private float _time;
    private void OnBeforeTransformParentChanged()
    {
        StartCoroutine("StartCountdown", _time);
    }
    private IEnumerator StartCountdown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
