using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowScaleRotPos : MonoBehaviour
{

    public TextMeshProUGUI xPos;
    public TextMeshProUGUI yPos;
    public TextMeshProUGUI zPos;

    public TextMeshProUGUI xScale;
    public TextMeshProUGUI yScale;
    public TextMeshProUGUI zScale;

    public TextMeshProUGUI xRot;
    public TextMeshProUGUI yRot;
    public TextMeshProUGUI zRot;

    public Texture2D currentTexture;

    public PlaceObjectScript changeScaleScript;
    public GameObject empty;


    private void Start()
    {
          
    }
    // Update is called once per frame
    void Update()
    {
        if (!changeScaleScript.currentPlaceableObject)
        {
            xPos.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.position.x).ToString();
            yPos.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.position.y).ToString();
            zPos.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.position.z).ToString();

            xScale.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.localScale.x).ToString();
            yScale.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.localScale.y).ToString();
            zScale.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.localScale.z).ToString();

            xRot.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.eulerAngles.x).ToString();
            yRot.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.eulerAngles.y).ToString();
            zRot.text = Mathf.Round(changeScaleScript.currentPlaceableObject.transform.eulerAngles.z).ToString();
        }

    }
}
