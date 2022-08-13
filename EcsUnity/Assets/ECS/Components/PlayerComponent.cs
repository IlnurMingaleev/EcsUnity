using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerComponent 
{
    public Rigidbody2D rigidbody2D;
    public Transform playerTransform;
    public Collider2D playerCollider;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
}
