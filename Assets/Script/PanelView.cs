using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelView : MonoBehaviour
{
    public int PanelNum { get; set; }
    public int PanelPos { get; set; }

    
    /// <summary>
    /// Move Panel
    /// </summary>
    /// <param name="num">next move point</param>
    public void SetPanelPos(int num)
    {

        
            var rectTransform = GetComponent<Image>().GetComponent<RectTransform>();
            var pos = rectTransform.localPosition;
            var x = num % 4;
            var y = num / 4;

            pos.x = -384 + x * 256;
            pos.y = 192 - y * 128;

            rectTransform.localPosition = pos;
            PanelPos = num;
    }
}
