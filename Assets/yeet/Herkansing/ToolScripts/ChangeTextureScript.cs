using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextureScript :MonoBehaviour, ICommand
{

    [Header("Change Texture Variables")]
    public Material[]   usableTextures;
    public GameObject   objectChange;
    public Renderer     objectRenderer;
    public GameObject[] textureObjects;

    private Material oldMaterial;
    private Material newMaterial;
    private GameObject objectToChangeMaterial;


    public void Execute()
    {
        objectToChangeMaterial.GetComponent<Renderer>().material = newMaterial;
    }

    public void Undo()
    {
        objectToChangeMaterial.GetComponent<Renderer>().material = oldMaterial;
    }

    public ChangeTextureScript(Material _oldMaterial, Material _newMaterial, GameObject _objectToChangeMaterial)
    {
        this.oldMaterial = _oldMaterial;
        this.newMaterial = _newMaterial;
        this.objectToChangeMaterial = _objectToChangeMaterial;
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

    public void ChangeTexture()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckObject();
        }

        for (int i = 0; i < usableTextures.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                objectRenderer.material = usableTextures[i];

                int t = 0;
                for (t = 0; t < usableTextures.Length; t++)
                { 
                    textureObjects[t]?.SetActive(false);
                    textureObjects[i]?.SetActive(true);
                }
            }
        }
    }
}
