using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Vector3 mousePos;
    void Update()
    {
        GetCurrentMousePos();
    }

    void GetCurrentMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
