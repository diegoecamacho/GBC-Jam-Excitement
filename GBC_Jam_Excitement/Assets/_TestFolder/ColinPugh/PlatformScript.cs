using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBCJam.ColorValues;

public class PlatformScript : MonoBehaviour {
    [Header("Movement Properties")]
    private bool IsRunning;
    private float MovementSpeed = 1.0f;
    private float KillZoneLimitX = -6.0f; //TODO: Find a proper killzone point

    [Header("Color Properties")]
    private EColor_Value assignedColor;
    public EColor_Value AssignedColor
    {
        get { return AssignedColor; }
        set { AssignedColor = value; }
    }
    private Material OwnedMaterial;

	// Use this for initialization
	void Start () {
        IsRunning = true;
        OwnedMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {

        //Kill zone
        if (transform.position.x <= KillZoneLimitX) {
            IsRunning = false;
            Destroy(this.gameObject, 0.3f);
        }

        //Move platform forward
        if (IsRunning)
        {
            transform.Translate(-1 * transform.right * MovementSpeed * Time.deltaTime, Space.World); //move left towards player
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("ColorBlock"))
        {
            EColor_Value BlockColor = other.GetComponent<ColorBlockScript>().GetColorValue; //get the color of the block
            FillPlatform(BlockColor); //apply the color
        }
    }

    private void FillPlatform(EColor_Value fillColor)
    {
        Color resultColor = ColorHelper.GetRealColor(fillColor); //convert enum to color
        OwnedMaterial.SetColor("_Color", resultColor);
    }
}
