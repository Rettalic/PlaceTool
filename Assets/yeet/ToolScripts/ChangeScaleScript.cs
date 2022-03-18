using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleScript : MonoBehaviour
{

    public float scaleSpeed;
    public GameObject scaleObject;

    Vector3 temp;
    private float xMouseWheelRotation;
    private float yMouseWheelRotation;
    private float zMouseWheelRotation;
    private float scrollSpeed = 1f;

    private bool xAxisBool;
    private bool yAxisBool;
    private bool zAxisBool;


    public void CheckObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            scaleObject = hit.transform.gameObject;
            Debug.Log(scaleObject.transform.localScale);
            scaleObject.transform.localScale = temp;
        }
    }

    public void ChangeScale()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CheckObject();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            xAxisBool = true;
            yAxisBool = false;
            zAxisBool = false;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            xAxisBool = false;
            yAxisBool = true;
            zAxisBool = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            xAxisBool = false;
            yAxisBool = false;
            zAxisBool = true;
        }

        if (xAxisBool) xMouseWheelRotation += Input.mouseScrollDelta.y;
        if (yAxisBool) yMouseWheelRotation += Input.mouseScrollDelta.y;
        if (zAxisBool) zMouseWheelRotation += Input.mouseScrollDelta.y;

        if (Input.GetKey(KeyCode.Q))
        {
            if (xAxisBool) xMouseWheelRotation -= scrollSpeed;
            if (yAxisBool) yMouseWheelRotation -= scrollSpeed;
            if (zAxisBool) zMouseWheelRotation -= scrollSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (xAxisBool) xMouseWheelRotation += scrollSpeed;
            if (yAxisBool) yMouseWheelRotation += scrollSpeed;
            if (zAxisBool) zMouseWheelRotation += scrollSpeed;
        }

        if (xMouseWheelRotation < 1)  xMouseWheelRotation = 1;
        if (yMouseWheelRotation < 1)  yMouseWheelRotation = 1;
        if (zMouseWheelRotation < 1)  zMouseWheelRotation = 1;
        if (xMouseWheelRotation > 10) xMouseWheelRotation = 10;
        if (yMouseWheelRotation > 10) yMouseWheelRotation = 10;
        if (zMouseWheelRotation > 10) zMouseWheelRotation = 10;

        if (Input.GetKeyDown(KeyCode.R))
        {
            xMouseWheelRotation = 0;
            zMouseWheelRotation = 0;
            yMouseWheelRotation = 0;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            scaleObject = null;
        }

        temp.x = xMouseWheelRotation;
        temp.y = yMouseWheelRotation;
        temp.z = zMouseWheelRotation;

        scaleObject.transform.localScale = temp; 


        temp = transform.localScale;
        transform.localScale = temp;
    }



}
