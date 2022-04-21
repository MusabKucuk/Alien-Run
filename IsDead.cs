using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDead : MonoBehaviour
{
    public bool IsCharacterDead = false;
    public LayerMask layerMaskAttackable;
    public LayerMask layerMaskPlatform;
    public LayerMask layerMaskMeteor;
    private Transform transfom;
    private float platformPosition, platformPosX;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody2D;
    private AnimationController animationController;
    public GameObject deadMenu;
    private AudioController audioController;
    public GameObject player;
    public Transform characters;
    public Transform cameraPosition;
    public GameObject cam;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
        transfom = GetComponent<Transform>();
        audioController = GetComponent<AudioController>();
    }

    public bool IsCollide()
    {
        if (IsCharacterDead == true) return false;

        RaycastHit2D raycastHit = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, Vector2.right, 0f, layerMaskAttackable);
        if(raycastHit.collider != null)
        raycastHit.transform.gameObject.GetComponent<Health>().TakeDamage(50);
        return raycastHit.collider != null;
    }
    public bool IsCollideMeteor()
    {
        if (IsCharacterDead == true) return false;

        RaycastHit2D raycastHit = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, Vector2.right, 0f, layerMaskMeteor);
    
        return raycastHit.collider != null;
    }

    public void PlatformPosition()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, Vector2.down, 0f, layerMaskPlatform);
       
        if (raycastHit.collider != null)
        {
            platformPosition = raycastHit.point.y;
            platformPosX = raycastHit.point.x;
        }       
    }

    public IEnumerator CharacterDead()
    {
        PlatformPosition();
        
        if (IsCollide() || IsCollideMeteor() || transform.position.y + 6 < platformPosition)
        {
            if (IsCharacterDead) yield break;
            IsCharacterDead = true;
            audioController.playDeadSound();
            animationController.PlayDieAnim();
            boxCollider.enabled = !boxCollider.enabled;
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX;         
            yield return new WaitForSeconds(1f);
            deadMenu.GetComponent<DeadMenu>().OpenDeadMenu();
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield break;
        }
    }

    public void countinuePlay()
    {
        IsCharacterDead = false;
        audioController.onGoingAudio.enabled = !audioController.onGoingAudio.enabled;
        boxCollider.enabled = !boxCollider.enabled;     
        player.transform.position = new Vector3(platformPosX, platformPosition + 2, player.transform.position.z);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        cam.GetComponent<CameraFollow>().camMovement = platformPosX - characters.position.x - 6;        
    }
}
