using System;
using UnityEngine;

public enum ToolState
{
    CreateObject  = 0,
    ChangeTexture = 1,
    ScaleObject   = 2,
    MoveObject    = 3,
    GroupObject   = 4
}

public class ToolManager : MonoBehaviour, ICommandHandler
{
    public ToolState toolState;

    public ChangeTextureScript changeTextureScript;
    public PlaceObjectScript   placeObjectScript;
    public ChangeScaleScript   changeScaleScript;

   // private List<> commandList = new List<>();

    public void Execute()
    {
    }
    public void Undo()
    {
    }
    
    private void Update()
    {
        ChangeToolState();
        HandleToolState();
    }
    
    private void ChangeToolState()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            toolState = ToolState.CreateObject;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            toolState = ToolState.ChangeTexture;
        }
    }

    private void HandleToolState()
    {
        switch (toolState)
        {
            case ToolState.CreateObject:
                PlaceObjectTotal();
                break;

            case ToolState.ChangeTexture:
                ChangeTextureTotal();
                break;
            case ToolState.ScaleObject:
                ChangeScaleTotal();
                break;

            case ToolState.MoveObject:

                break;

            case ToolState.GroupObject:

                break;
        }
    }

    private void ChangeTextureTotal()
    {
        changeTextureScript.ChangeTexture();
    }
    private void PlaceObjectTotal()
    {
        placeObjectScript.HandleNewObjectHotkey();
        placeObjectScript.ExecuteTasksPlaceObject();
    }

    private void ChangeScaleTotal()
    {
        changeScaleScript.ChangeScale();
    }

    public void ChangeToolThroughButton(int toolValue)
    {
        if(toolValue == 0)
        {
            toolState = ToolState.CreateObject;
        }
        if (toolValue == 1)
        {
            toolState = ToolState.ChangeTexture;
        }
        if (toolValue == 2)
        {
            toolState = ToolState.ScaleObject;
        }
        if (toolValue == 3)
        {
            toolState = ToolState.MoveObject;
        }
        if (toolValue == 4)
        {
            toolState = ToolState.GroupObject;
        }
    }    
}