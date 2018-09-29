using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBCJam.ColorValues;

public class PlatformScript : MonoBehaviour {
    [Header("Movement Properties")]
    private bool isRunning;
    private float movementSpeed = 1.0f;
    private float killZoneLimitX = -6.0f; //TODO: Find a proper killzone point
    Vector3 cameraWorldBounds;

    [Header("Color Properties")]
    private EColor_Value assignedColor;
    public EColor_Value AssignedColor
    {
        get { return AssignedColor; }
        set { AssignedColor = value; }
    }
    private Material OwnedMaterial;

    // Spawner Reference
    SpawnerController spawnerController;

	// Use this for initialization
	void Start () {
        isRunning = true;
        OwnedMaterial = GetComponent<Renderer>().material;

        spawnerController = GameObject.Find("GameManager").GetComponent<SpawnerController>();

        //getting the camera world bound extent
        double VerticalHightSeen = Camera.main.orthographicSize * 2.0;
        double HorizontalHeightSeen = VerticalHightSeen * Screen.width / Screen.height;
        cameraWorldBounds = Camera.main.transform.position;
        cameraWorldBounds.x += (float)HorizontalHeightSeen; //TODO: Check if this is the actual valid world bound
    }

    // Update is called once per frame
    void Update () {

        //Kill zone
        if (transform.position.x <= killZoneLimitX) {
            isRunning = false;
            Destroy(this.gameObject, 0.3f);
        }

        //Move platform forward
        if (isRunning)
        {
            transform.Translate(-1 * transform.right * movementSpeed * Time.deltaTime, Space.World); //move left towards player
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if block enter
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

        //notify controller that you have been filled
        spawnerController.NotifyRemovePlatform();
    }
}
