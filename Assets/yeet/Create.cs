using System;
using UnityEngine;


public enum ToolState
{
    CreateObject,
    ChangeTexture,
    MoveObject,
    GroupObject
}

[ExecuteInEditMode]
public class Create : MonoBehaviour, ICommandHandler
{
    public ToolState toolState;

    [Header("Create Object Variables")]
    [SerializeField]
    private GameObject[] placeableObjectPrefabs;
    private GameObject   currentPlaceableObject;

    private float xMouseWheelRotation;
    private float yMouseWheelRotation;
    private float zMouseWheelRotation;

    private int   currentPrefabIndex = -1;
    private float scrollSpeed = 0.1f;

    private bool xAxisBool;
    private bool yAxisBool;
    private bool zAxisBool;

    [Header("Change Texture Variables")]
    public Texture[]  usableTextures;
    public GameObject objectChange;
    public Renderer   objectRenderer;

    [Header("Move Object Variables")]
    private int temp;

    [Header("Group Object Variables")]
    private int temp2;

    
    public void Execute()
    {
    }

    public void Undo()
    {
    }
    
    private void Update()
    {
        switch (toolState)
        {
            case ToolState.CreateObject:
                PlaceObjectTotal();
                break;
            case ToolState.ChangeTexture:
                ChangeTextureTotal();
                break;
            case ToolState.MoveObject:

                break;
            case ToolState.GroupObject:

                break;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            toolState = ToolState.CreateObject;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            toolState = ToolState.ChangeTexture;
        }
    }

    private void ChangeTextureTotal()
    {
        ChangeTexture();
        CheckObject();
    }
    private void PlaceObjectTotal()
    {
        HandleNewObjectHotkey();
        ExecuteTasksPlaceObject();
    }

    private void ExecuteTasksPlaceObject()
    {
        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            xAxisBool = true;
            yAxisBool = false;
            zAxisBool = false;
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            xAxisBool = false;
            yAxisBool = true;
            zAxisBool = false;
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            xAxisBool = false;
            yAxisBool = false;
            zAxisBool = true;
        }
        if (Input.GetKeyDown(KeyCode.R)) ResetRotation();
    }

    private void HandleNewObjectHotkey()
    {
        for (int i = 0; i < placeableObjectPrefabs.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
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

    private void RotateFromMouseWheel()
    {
        //Debug.Log(Input.mouseScrollDelta);

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

        currentPlaceableObject.transform.Rotate(Vector3.up,      xMouseWheelRotation * 10f);
        currentPlaceableObject.transform.Rotate(Vector3.left,    yMouseWheelRotation * 10f);
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
            currentPlaceableObject.layer = 0;
            currentPlaceableObject = null;
        }
    }

    public void ChangeTexture()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CheckObject();
        }

        for (int i = 0; i < usableTextures.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                objectRenderer.material.mainTexture = usableTextures[i];
            }
        }
    }

    private void CheckObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            objectChange = hit.transform.gameObject;
            objectRenderer = objectChange.GetComponent<Renderer>();
        }
    }
}