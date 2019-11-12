using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControll : MonoBehaviour
{
    public int c = 0;
    public bool flag = false;   
    private int voidPanelNum = 15;
    [SerializeField]
    private Image[] panelImages;
    // Start is called before the first frame update

    void Start()
    {

        for(int i = 0; i < 16; i++)
        {
            var rectTransform = panelImages[i].GetComponent<RectTransform>();
            var pos = rectTransform.localPosition;
            var x = i % 4;
            var y = i / 4;

            pos.x = -384 + x * 256;
            pos.y =  192 - y * 128;

            rectTransform.localPosition = pos;
            panelImages[i].GetComponent<PanelView>().PanelNum = i;
            panelImages[i].GetComponent<PanelView>().PanelPos = i;
        }
        
        panelImages[voidPanelNum].gameObject.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {   
    }


    /// <summary>
    /// if pressed button, Image is Moveing
    /// </summary>
    /// <param name="num">Image number</param>
    public void OnClickButton(int num)
    {
        var panelScript = panelImages[num].GetComponent<PanelView>();
        var panelPos = panelScript.PanelPos;

        //panel is check left
        if ((panelPos % 4) == 0)
        {
            if (panelPos + 1 == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, 1);
                return;
            }

        }


        else if ((panelPos % 4) == 3)
        {
            
            if (panelPos - 1 == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, -1);
                return;
            }

        }
        else
        {

            if (panelPos - 1 == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, -1);
                return;
            }

            if (panelPos + 1 == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, 1);
                return;
            }
        }

        //panel is check top
        if ((panelPos / 4) == 0)
        {
            if ((panelPos  + 4) == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, +4);
                return;
            }

            
        }

        //panel is check bottom
        else if ((panelPos / 4) == 3)
        {
       
            if ((panelPos - 4) == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, -4);
                return;
            }
        }

        else
        {
            if ((panelPos + 4) == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, 4);
                return;
            }

            if ((panelPos - 4) == voidPanelNum)
            {
                ChangePanelCheck(panelScript, panelPos, -4);
                return;
            }

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="panelScript"></param>
    /// <param name="panelPos"></param>
    /// <param name="addCount"></param>
    /// <returns></returns>
    private bool ChangePanelCheck(PanelView panelScript, int panelPos, int addCount)
    {
        if (panelPos + addCount == voidPanelNum)
        {
            voidPanelNum = panelPos;

            panelScript.SetPanelPos(panelPos + addCount);
        }
        return true;
    }
}
