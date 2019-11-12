using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

    public GameObject Player;

    //bool pressed = false;

    [SerializeField]
    private Text t;


    public void OnTestButton()
    {
        /*pressed = !pressed;

        if (pressed)
        {
            Debug.Log("Press Button");
            t.text = "change";
        }

        else
        {
            Debug.Log("Press Button");
            t.text = "Defalt";
        }
        */
    }

    public void ImageMove()
    {

        //  GameObject.Find("PanelArea").GetComponent<PanelControll>().c++;
        //  GameObject.Find("PanelArea").GetComponent<PanelControll>().flag = true;
     
    }

}