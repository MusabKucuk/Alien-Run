using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour
{
    public enum States
    {
        Idle,
        Jump,
        Run,
        Fire
    }

    public enum chracterDirection
    {
        right,
        left
    }

    [Header("Movement Values")]
    private float movementSpeed;
    private float jumpForce = 11f;

    [Header("Raycast")]
    public LayerMask platformLayerMask;
    public float groundedHeight;

    [Header("Movement States")]
    public States characterStates;
    public chracterDirection direction;

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private AnimationController animController;
    private CharacterCombat characterCombat;
    private IsDead isDead;
    private AudioController audioController;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animController = GetComponent<AnimationController>();
        characterCombat = GetComponent<CharacterCombat>();
        isDead = GetComponent<IsDead>();
        audioController = GetComponent<AudioController>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        SetCharacterState();
        animController.Animations();
        CharacterDirection();
    }

    public void Move()
    {
        if (isDead.IsCharacterDead)
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            return;
        }
        else
        {
            movementSpeed = CrossPlatformInputManager.GetAxis("Horizontal") * 9;
            rigidBody.velocity = new Vector2(movementSpeed, rigidBody.velocity.y);
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;       
        }
    }

    public void Jump()
    {
        if (IsGrounded() && !isDead.IsCharacterDead && CrossPlatformInputManager.GetButtonDown("Jump"))//&& Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            audioController.playJumpSound();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, Vector2.down, groundedHeight, platformLayerMask);

        return raycastHit.collider != null;
    }

    private void SetCharacterState()
    {
        if (characterCombat.isFiring) return;

        if (IsGrounded())
        {
            if (rigidBody.velocity.x == 0)
            {
                characterStates = States.Idle;
            }
            else
            {
                characterStates = States.Run;
                if (rigidBody.velocity.x > 0) direction = chracterDirection.right;
                if (rigidBody.velocity.x < 0) direction = chracterDirection.left;
            }
        }
        else
        {
            characterStates = States.Jump;
            if (rigidBody.velocity.x > 0) direction = chracterDirection.right;
            if (rigidBody.velocity.x < 0) direction = chracterDirection.left;
        }
    }

    private void CharacterDirection()
    {
        switch (direction)
        {
            case chracterDirection.right:
                spriteRenderer.flipX = false;
                break;
            case chracterDirection.left:
                spriteRenderer.flipX = true;
                break;
            default:
                break;
        }
    }
}
