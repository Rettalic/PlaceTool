using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleScript : MonoBehaviour
{
    public float      scaleSpeed;
    public GameObject scaleObject;
    public LayerMask layerMask;

    Vector3 temp;
    private float xMouseWheelRotation;
    private float yMouseWheelRotation;
    private float zMouseWheelRotation;
    private float scrollSpeed = 1f;

    private bool xAxisBool;
    private bool yAxisBool;
    private bool zAxisBool;

    private void Start()
    {
        scaleObject = null;
    }

    public void CheckObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            scaleObject = hit.transform.gameObject;
            scaleObject.transform.localScale = temp;
        }
    }

    public void ChangeScale()
    {
        if (Input.GetMouseButtonDown(0))  CheckObject();
        if (Input.GetKeyDown(KeyCode.X))
        {   xAxisBool = true;
            yAxisBool = false;
            zAxisBool = false;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {   xAxisBool = false;
            yAxisBool = true;
            zAxisBool = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {   xAxisBool = false;
            yAxisBool = false;
            zAxisBool = true;
        }

        if (xAxisBool) xMouseWheelRotation += Input.mouseScrollDelta.y;
        if (yAxisBool) yMouseWheelRotation += Input.mouseScrollDelta.y;
        if (zAxisBool) zMouseWheelRotation += Input.mouseScrollDelta.y;

        if (Input.GetKey(KeyCode.Q))
        {   if (xAxisBool) xMouseWheelRotation -= scrollSpeed;
            if (yAxisBool) yMouseWheelRotation -= scrollSpeed;
            if (zAxisBool) zMouseWheelRotation -= scrollSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {   if (xAxisBool) xMouseWheelRotation += scrollSpeed;
            if (yAxisBool) yMouseWheelRotation += scrollSpeed;
            if (zAxisBool) zMouseWheelRotation += scrollSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {   xAxisBool = true;
            yAxisBool = true;
            zAxisBool = true;
        }

        if (xMouseWheelRotation < 0.5f)  xMouseWheelRotation = 0.5f;
        if (yMouseWheelRotation < 0.5f)  yMouseWheelRotation = 0.5f;
        if (zMouseWheelRotation < 0.5f)  zMouseWheelRotation = 0.5f;
        if (xMouseWheelRotation > 10) xMouseWheelRotation = 10;
        if (yMouseWheelRotation > 10) yMouseWheelRotation = 10;
        if (zMouseWheelRotation > 10) zMouseWheelRotation = 10;

        if (Input.GetKeyDown(KeyCode.R))
        {   xMouseWheelRotation = 0;
            zMouseWheelRotation = 0;
            yMouseWheelRotation = 0;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) scaleObject = null;

        temp.x = xMouseWheelRotation;
        temp.y = yMouseWheelRotation;
        temp.z = zMouseWheelRotation;

        if(scaleObject != null)
        {
        scaleObject.transform.localScale = temp; 
        temp = transform.localScale;
        transform.localScale = temp;
        }
    }
}
