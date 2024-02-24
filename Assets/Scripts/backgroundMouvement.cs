using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class backgroundMouvement : MonoBehaviour
{
    public static float speed = 1.5f;
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(-speed, 0);
        if (rectTransform.anchoredPosition.x <= -1745.4f)
        {
            rectTransform.anchoredPosition = new Vector2(1503.4f, -10);
        }
    }
    public static void Stop()
    {
        speed = 0;
    }
}
