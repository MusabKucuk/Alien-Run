using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject[] platforms;
	public Transform cameraPosition;

	public Vector3 firstEndPoint;
	
	public GameObject avatar1, avatar2, avatar3, avatar4;

	/*public enum Player
    {
		GreenAlien,
		MaskAlien
    }*/
	//private Player SelectAvatar;
	private Platform platformScript;

	private int platformCount = 0;
	public void SpawnPlotforms()
	{
     	if (cameraPosition.position.x + 20 > platformScript.returnEndPoint().x)
		{
			GameObject platform = GameObject.Instantiate(platforms[Random.Range(0, platforms.Length)]);
	        platformScript = platform.GetComponent<Platform>(); 
     		platform.transform.position = firstEndPoint;
			firstEndPoint = platformScript.returnEndPoint();	
			platformCount++;
		}

		if (platformCount == 6)
		{
			Destroy(GameObject.FindGameObjectWithTag("Platform"));
			platformCount--;
		}

	}

	/*public void PlayerChoice()
    {
        switch (SelectAvatar)
        {
			case Player.GreenAlien:
				
				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(true);
				break;

			case Player.MaskAlien:
				
				avatar1.gameObject.SetActive(true);
				avatar2.gameObject.SetActive(false);
				break;
        }
    }*/

	

	private void Awake()
	{
		platformScript = GetComponent<Platform>();
	}

    void Start()
    {
		//PlayerChoice();
	}
	
	private void FixedUpdate() 
	{
		SpawnPlotforms();
	}
	
}
