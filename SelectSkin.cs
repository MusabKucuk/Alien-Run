using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour
{
	private GameObject[] characterList;
	private int index;

    private void Awake()
    {
		index = PlayerPrefs.GetInt("SelectedCharacter");
		characterList = new GameObject[transform.childCount];

		if (index >= characterList.Length) index = 0;
		if (index < 0) index = transform.childCount - 1; 
		
		for (int i = 0; i < transform.childCount; i++)
        {
			characterList[i] = transform.GetChild(i).gameObject;
        }
		
        foreach (GameObject item in characterList)
        {
			item.SetActive(false);
        }

		if (characterList[index])
        {
			characterList[index].SetActive(true);
		}
	}
    public void next()
	{
		characterList[index].SetActive(false);
		index++;

        if (index >= characterList.Length)
        {
			index = 0;
        }

		characterList[index].SetActive(true);
		PlayerPrefs.SetInt("SelectedCharacter", index);
	}

	public void back()
	{
		characterList[index].SetActive(false);
		index--;

        if (index < 0)
        {
			index = characterList.Length - 1;
		}

		characterList[index].SetActive(true);
		PlayerPrefs.SetInt("SelectedCharacter", index);
	}
}
