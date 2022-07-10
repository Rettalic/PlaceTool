using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ToolState
{
    CreateObject  = 0,
    ChangeTexture = 1,
    ScaleObject   = 2,
    MoveObject    = 3

}

public class ToolManager : MonoBehaviour, ICommand
{
    [Header("Tool")]
    public ToolState toolState;

    private ChangeTextureScript changeTextureScript;
    private PlaceObjectScript placeObjectScript;
    private ChangeScaleScript changeScaleScript;
    private MoveObjectScript moveObjectScript;

    [Header("Changeable keycodes: ")]
    public KeyCode createObject;
    public KeyCode changeTexture;
    public KeyCode scaleObject;
    public KeyCode moveObject;

    [Header("Button text: ")]
    public TextMeshProUGUI createText;
    public TextMeshProUGUI textureText;
    public TextMeshProUGUI scaleText;
    public TextMeshProUGUI moveText;

    [Header("Tips:")]
    public GameObject createHelp;
    public GameObject textureHelp;
    public GameObject scaleHelp;
    public GameObject moveHelp;

    // private List<> commandList = new List<>();


    private void Start()
    {
        changeTextureScript = GetComponent<ChangeTextureScript>();
        placeObjectScript   = GetComponent<PlaceObjectScript>();
        changeScaleScript   = GetComponent<ChangeScaleScript>();
        moveObjectScript    = GetComponent<MoveObjectScript>();

        createText.text  = "Create Object (" + createObject.ToString() + ")";
        textureText.text = "Change Texture (" + changeTexture.ToString() + ")";
        scaleText.text   = "Scale Object (" + scaleObject.ToString() + ")";
        moveText.text    = "Move Object (" + moveObject.ToString() + ")";

        createHelp.SetActive(false);
        textureHelp.SetActive(false);
        scaleHelp.SetActive(false);
        moveHelp.SetActive(false);
    }

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
        if (Input.GetKeyDown(createObject))  toolState = ToolState.CreateObject;
        if (Input.GetKeyDown(changeTexture)) toolState = ToolState.ChangeTexture;
        if (Input.GetKeyDown(scaleObject))   toolState = ToolState.ScaleObject;
        if (Input.GetKeyDown(moveObject))    toolState = ToolState.MoveObject;
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
                MoveObjectTotal();
                break;
        }
    }

    private void ChangeTextureTotal()
    {
        changeTextureScript?.ChangeTexture();
    }
    private void PlaceObjectTotal()
    {
        placeObjectScript?.HandleNewObjectHotkey();
        placeObjectScript?.ExecuteTasksPlaceObject();
    }

    private void ChangeScaleTotal()
    {
        changeScaleScript?.ChangeScale();
    }

    private void MoveObjectTotal()
    {
        moveObjectScript.ExecuteTasksMoveObject();
    }

    public void ChangeToolThroughButton(int toolValue)
    {
        if (toolValue == 0)
        {
            toolState = ToolState.CreateObject;
            createText.text = "Create Object (" + createObject.ToString() + ")";
        }

        if (toolValue == 1)
        {
            toolState = ToolState.ChangeTexture;
            textureText.text = "Change Texture (" + changeTexture.ToString() + ")";
        }

        if (toolValue == 2)
        {
            toolState = ToolState.ScaleObject;
            scaleText.text = "Scale Object (" + scaleObject.ToString() + ")";
        }
   
        if (toolValue == 3)
        {
            toolState = ToolState.MoveObject;
            moveText.text = "Move Object (" + moveObject.ToString() + ")";
        }
    }
    
    public void helpButton(int value)
    {
        if (value == 0)
        {
            createHelp.SetActive(true);
        }
        else
        {
            createHelp.SetActive(false);
        }
        if (value == 1)
        {
            textureHelp.SetActive(true);
        }
        else
        {
            textureHelp.SetActive(false);
        }
        if (value == 2)
        {
            scaleHelp.SetActive(true);
        }
        else
        {
            scaleHelp.SetActive(false);
        }
        if (value == 3)
        {
            moveHelp.SetActive(true);
        }
        else
        {
            moveHelp.SetActive(false);
        }
        if(value == 4)
        {
            createHelp.SetActive(false);
            textureHelp.SetActive(false);
            scaleHelp.SetActive(false);
            moveHelp.SetActive(false);
        }

    }
}