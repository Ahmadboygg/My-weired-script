using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform playerSpawnPoint;
    private SelectCharacter selectCharacter;
    private List<GameObject> players;
    private int index;

    void Start()
    {
        players = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/Players"));
        if(!PlayerPrefs.HasKey("Character Index"))
        {
            PlayerPrefs.SetInt("Character Index", 0);
            Load();
        }
        else
        {
            Load();
        }
        Instantiate(players[index],playerSpawnPoint.position,playerSpawnPoint.rotation);
    }

    void Load()
    {
        index = PlayerPrefs.GetInt("Character Index");
    }
}
