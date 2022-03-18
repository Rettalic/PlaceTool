using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextureScript :MonoBehaviour
{

    [Header("Change Texture Variables")]
    public Texture[] usableTextures;
    public GameObject objectChange;
    public Renderer objectRenderer;

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

    public void CheckObject()
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
