using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    #region Member Fields
    /// <summary>
    /// Mouse co-ordinates in WorldSpace
    /// </summary>
    public static Vector3 touch;

    #endregion

    #region default functions

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }
    #endregion
}