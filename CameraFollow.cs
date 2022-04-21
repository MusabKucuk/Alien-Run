using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public Vector3 offSet;
    public float camMovement=0;
    public float camMovementSpeed;
    public Camera mainCamera;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    
    private void FixedUpdate()
    {
        ActiveAvatar();
        CamFollowSelectedAvatar();
    }

    private void ActiveAvatar()
    {
        if (player != GameObject.FindGameObjectWithTag("Green Player").transform)
        {
            player = GameObject.FindGameObjectWithTag("Green Player").transform;
        }
    }
    private void CamFollowSelectedAvatar()
    {
        mainCamera.transform.position = new Vector3(camMovement + offSet.x, player.position.y + offSet.y, offSet.z);
        if (player.GetComponent<IsDead>().IsCharacterDead) return;
        camMovement += camMovementSpeed / 100;
        if (camMovementSpeed < 10f) camMovementSpeed += 0.0015f;
        if (camMovementSpeed < 14.5f && camMovementSpeed > 10f) camMovementSpeed += 0.0008f;
    }
}
