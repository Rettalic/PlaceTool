using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Texture[] usableTextures;
    public GameObject objectChange;
    public Renderer objectRenderer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
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
