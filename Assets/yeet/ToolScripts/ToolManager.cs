using System;
using UnityEngine;
public enum ToolState
{
    CreateObject,
    ChangeTexture,
    MoveObject,
    GroupObject
}

public class ToolManager : MonoBehaviour, ICommandHandler
{
    public ToolState toolState;

    public ChangeTextureScript changeTextureScript;
    public PlaceObjectScript placeObjectScript;

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
        changeTextureScript.ChangeTexture();
        changeTextureScript.CheckObject();
    }
    private void PlaceObjectTotal()
    {
        placeObjectScript.HandleNewObjectHotkey();
        placeObjectScript.ExecuteTasksPlaceObject();
    }

    

    
}