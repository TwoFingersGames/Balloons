using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripper : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.TryGetComponent(out Blade blade))
        {
            Instantiate(_explosion, gameObject.transform.position, Quaternion.identity);
        }
    }
}
