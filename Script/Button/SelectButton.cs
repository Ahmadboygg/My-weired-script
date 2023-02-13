using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private List<Button> button;
    [SerializeField] private int buttonNumber;
    void Start()
    {
        buttonNumber = 0;
    }

    void Update()
    {
        button[buttonNumber].Select();
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(buttonNumber < button.Count -1)
            {
                buttonNumber++;
            }
            else if(buttonNumber >= button.Count-1)
            {
                buttonNumber = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(buttonNumber > 0)
            {
                buttonNumber--;
            }
            else if(buttonNumber <= 0)
            {
                buttonNumber = button.Count-1;;
            }
        }
    }
}
