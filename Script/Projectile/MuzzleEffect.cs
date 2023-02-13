using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleEffect : MonoBehaviour
{
    [SerializeField]private float timer;
    void Start()
    {
        Invoke("Destroy",timer);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
