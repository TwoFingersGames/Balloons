using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(UntieTheBall))]
[RequireComponent(typeof(Ripper))]
[RequireComponent(typeof(BalloonEvents))]
[RequireComponent(typeof(Animator))]

public class Balloon : MonoBehaviour
{
    [SerializeField] private float _flyForce;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    public int Index;
    public State SelectBall = new State();

    public bool AbleToFly = true;

    public event UnityAction<Balloon> Click;

    

    
    
    
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponentInChildren<Animator>();
    }
    private void OnMouseDown()
    {
        Click?.Invoke(this);
    }
    public void SetColor(Color32 color)
    {
        _spriteRenderer.color = color;
    }

    public void Atack(Vector2 target)
    {
        _animator.Play("Atack");
        StartCoroutine(Atack());
    }
    private IEnumerator Fly()
    {
        if (AbleToFly)
        {
            _rigidbody.AddForce(transform.up*_flyForce, ForceMode2D.Force);
            yield return new WaitForFixedUpdate();
            StartCoroutine(Fly());
        }
        else
        {
            yield break;
        }
        
    }

    private IEnumerator Atack()
    {
        yield return new WaitForFixedUpdate();
    }

}
public enum State
{
    None,
    First,
    Second
}
