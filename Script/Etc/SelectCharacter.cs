using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{   
    [SerializeField] private GameObject[] characterSelectObject;
    [SerializeField] private int index;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Character Index"))
        {
            PlayerPrefs.SetInt("Character Index", 0);
            Load();
        }
        else
        {
            Load();
        }
    }

    void Update()
    {
        for(int i = 0; i <= characterSelectObject.Length -1; i++)
        {
            if(i == index)
            {
                characterSelectObject[i].SetActive(true);
            }
            else
            {
                characterSelectObject[i].SetActive(false);

            }
        }
    }

    public void NextSelectedObject()
    {
        if(index < characterSelectObject.Length -1)
        {
            index++;
        }
        else if(index >= characterSelectObject.Length -1)
        {
            index = 0;
        }
        Save(index);
    }

    public void PreviousSelectedObject()
    {
        if(index > 0)
        {
            index--;
        }
        else if(index <= 0)
        {
            index = characterSelectObject.Length -1;;
        }
        Save(index);
    }

    void Save(int value)
    {
        PlayerPrefs.SetInt("Character Index", value);
    }

    void Load()
    {
        index = PlayerPrefs.GetInt("Character Index");
    }
}
