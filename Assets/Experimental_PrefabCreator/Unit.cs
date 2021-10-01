using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Unit : MonoBehaviour
{
    public int Index;
    public SpriteRenderer    SpriteRenderer;
    public Rigidbody2D       Rigidbody2D;
    public PolygonCollider2D Collider;
    public Animator          Animator;
    public AnimationClip     Custom;
    public AnimationClip     Atack;
    private void OnEnable()
    {
        //this.Animator.Play(nameof(Custom));
    }

    

}
