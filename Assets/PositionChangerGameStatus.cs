using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionChangerGameStatus : MonoBehaviour
{
    public static PositionChangerGameStatus instance;
    public RectTransform middleRect;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void changePosition()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = middleRect.anchoredPosition;
    }

}
