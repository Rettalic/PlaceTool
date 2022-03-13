using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Texture[] usableTextures;
    public GameObject objectChange;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            CheckObject();
        }
    }

    private void CheckObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            objectChange = hit.transform.gameObject;    
        }
    }
}
