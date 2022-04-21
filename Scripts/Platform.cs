using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
	
	public Vector3 returnEndPoint()
	{
		Vector3 calculatedEndPoint;
		calculatedEndPoint.x = spriteRenderer.bounds.size.x + this.transform.position.x + Random.Range(2f, 3.8f);
		calculatedEndPoint.y = this.transform.position.y + Random.Range(-2.5f, 1.8f);
		calculatedEndPoint.z = 0;
		return calculatedEndPoint;
	}
}
