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
    public PlaceObjectScript placeObjectScript;
    public ChangeScaleScript changeScaleScript;

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
            case ToolState.ScaleObject:
                ChangeScaleTotal();
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
        //changeTextureScript.CheckObject();
        changeTextureScript.ChangeTexture();
    }
    private void PlaceObjectTotal()
    {
        placeObjectScript.HandleNewObjectHotkey();
        placeObjectScript.ExecuteTasksPlaceObject();
    }

    private void ChangeScaleTotal()
    {
        //changeTextureScript.CheckObject();
        changeScaleScript.ChangeScale();
    }

    public void ChangeThroughButton(int toolValue)
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