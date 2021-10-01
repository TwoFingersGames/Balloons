using System.Collections;
using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private float[] _lifeTimes;
    private void Awake()
    {
        _particles = gameObject.GetComponentsInChildren<ParticleSystem>();
        _lifeTimes = new float[_particles.Length];
        for (int i = 0; i < _particles.Length; i++)
        {
            _lifeTimes[i] = _particles[i].main.startLifetime.constant;
        }

        IComparer revComparer = new ReverseComparer();
        Array.Sort(_lifeTimes, revComparer);
        _maxLifeTime = _lifeTimes[0];
    }
    private void OnEnable()
    {
        foreach (var particle in _particles)
        {
            particle.Play();
        }
        StartCoroutine("AutoDestroy");
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(_maxLifeTime);
        Destroy(gameObject);
    } 
}

