using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour
{
    [Header("Create Object Variables")]

    [SerializeField] private GameObject[] placeableObjectPrefabs;
    [SerializeField] public GameObject currentPlaceableObject;

    public bool isSelected;

    private float xMouseWheelRotation;
    private float yMouseWheelRotation;
    private float zMouseWheelRotation;

    private int currentPrefabIndex = -1;
    private float scrollSpeed = 0.1f;

    private bool xAxisBool;
    private bool yAxisBool;
    private bool zAxisBool;
    public LayerMask layerMask;

    [SerializeField] GameObject objectChange;

    public void ExecuteTasksMoveObject()
    {
        SelectObject();
        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
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
        if (Input.GetKeyDown(KeyCode.R)) ResetRotation();

    }

    public void DeleteObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                objectChange = hit.transform.gameObject;
                if (objectChange.layer == 6)
                {
                    objectChange.layer = 0;
                    Destroy(objectChange);
                }
            }
        }
    }

    public void HandleNewObjectHotkey()
    {
        if (isSelected)
        {
            for (int i = 0; i < placeableObjectPrefabs.Length; i++)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (PressedKeyOfCurrentPrefab(i))
                    {
                        Destroy(currentPlaceableObject);
                        currentPrefabIndex = -1;
                    }
                    else
                    {
                        if (currentPlaceableObject != null)
                        {
                            Destroy(currentPlaceableObject);
                        }
                        currentPlaceableObject = Instantiate(placeableObjectPrefabs[i]);
                        currentPrefabIndex = i;
                        currentPlaceableObject.layer = 2;
                    }
                    break;
                }
            }
        }
    }

    private bool PressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceableObject != null && currentPrefabIndex == i;
    }

    private void MoveCurrentObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void SelectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, layerMask))
            {
                currentPlaceableObject = hit.transform.gameObject;
                Destroy(hit.transform.gameObject);
            }
            isSelected = true;
        }
    }

    private void RotateFromMouseWheel()
    {
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

        currentPlaceableObject.transform.Rotate(Vector3.up, xMouseWheelRotation * 10f);
        currentPlaceableObject.transform.Rotate(Vector3.left, yMouseWheelRotation * 10f);
        currentPlaceableObject.transform.Rotate(Vector3.forward, zMouseWheelRotation * 10f);
    }
    private void ResetRotation()
    {
        xMouseWheelRotation = 0;
        yMouseWheelRotation = 0;
        zMouseWheelRotation = 0;
    }
    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject.layer = 6;
            currentPlaceableObject = null;
            isSelected = false;
        }
    }
}
