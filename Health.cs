using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Health : MonoBehaviour
{
    public int health;
    public BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        gameObject.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
        this.gameObject.transform.DOShakeScale(0.15f, 0.8f, 5, 10);
        Tween colorTween = this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => this.gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(Color.white, 0.1f));
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (health <= 0)
        {
            health = 0;
            boxCollider2D.enabled = !boxCollider2D.enabled;
            spriteRenderer.flipY = true;
            animator.enabled = !animator.enabled;
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
