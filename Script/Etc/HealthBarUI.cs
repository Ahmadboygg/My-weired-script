using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject[] healthBarUI;
    private int _numberOfHeart;
    public int numberOfHeart
    {
        get { return _numberOfHeart;}
        set { _numberOfHeart = value;}
    }
    void Update()
    {
        if(_numberOfHeart >= healthBarUI.Length)
        {
            _numberOfHeart = healthBarUI.Length;
        }

        for(int i = 0; i <= healthBarUI.Length -1; i++)
        {
            healthBarUI[i].SetActive(false);
        }
        for(int i = 0; i <= _numberOfHeart -1; i++)
        {
            healthBarUI[i].SetActive(true);
        }
    }

    public void HealthToHeartNumber(int value)
    {
        value = _numberOfHeart;
    }
}
