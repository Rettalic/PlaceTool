using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Camera mainCam;
    private RaycastHit hit;

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private CommandManager commandManager;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                commandManager.ExecuteCommand(new InstantiateCommand(cubePrefab, hit.point));
            }
        }
    }
}