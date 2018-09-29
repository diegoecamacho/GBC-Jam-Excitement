using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBCJam.ColorValues;

public class ColorBlockScript : MonoBehaviour {

    [Header("Block Properties")]
    [SerializeField]
    private EColor_Value ColorValue = EColor_Value.NONE;
    public EColor_Value GetColorValue { get { return ColorValue; } }

    [Header("Throw Properties")]
    private bool isThrown = false;
    private float ThrowStep = 0.0f; //lerp step value
    [SerializeField]
    private float AnimRotationSpeed = 1.0f;
    [SerializeField]
    private float ThrowSpeed = 1.0f;
    private Vector3 ThrowStartPos;
    [SerializeField]
    private Vector3 ThrowEndPos;
    [SerializeField]
    private Vector3 ThrowMidPos;
    [SerializeField]
    private Transform ThrowAmplitudeObject;
    [SerializeField]
    private Transform ThrowEndObject;

    // SPAWNER REFERENCE
    SpawnerController spawnerController;

    private void Start()
    {
        // set throw vectors
        ThrowStartPos = transform.position;
        ThrowMidPos = ThrowAmplitudeObject.position;
        //ThrowEndPos = ThrowEndObject.position;

        spawnerController = GameObject.Find("GameManager").GetComponent<SpawnerController>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //HACK: To be updated with touch event
        {
            if (ValidateThrowProperties())
                isThrown = true;
        }

        if (isThrown)
        {
            ThrowTowardsTarget();
            AnimateCubeRotation();
        }

    }

    // Public function to call for throw
    public void ThrowCube(Vector2 throwDir, float magnitude)
    {
        //ThrowMidPos = new Vector3(throwDir.x, throwDir.y, 0.0f) * magnitude;

        if (ValidateThrowProperties())
            isThrown = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        // check if the cube has hit the platform
        if (collider.gameObject.tag.Equals("Platform"))
        {
            //TODO: Maybe check if the platform you hit has been filled?
            //Delete color block and create new one in Toolbar manager
            //isThrown = false;
            // Filling platform color is done by platformScript
        }
    }

    // Checks if a throw is possible and sets up various properties for the throw
    bool ValidateThrowProperties()
    {
        ThrowEndObject = spawnerController.GetThrowablePosition();

        if (ThrowEndObject == null)
            return false;

        return true;
    }

    // Moves the cube towards the end position on a curve determined by an midway height
    private void ThrowTowardsTarget()
    {
        if (ThrowStep < 1.0f) //check if it has fully lerped
        {
            ThrowEndPos = ThrowEndObject.position; // keep updating end position

            ThrowStep += ThrowSpeed * Time.deltaTime; //update lerp step

            Vector3 curve1 = Vector3.Lerp(ThrowStartPos, ThrowMidPos, ThrowStep); //get first bezier curve point
            Vector3 curve2 = Vector3.Lerp(ThrowMidPos, ThrowEndPos, ThrowStep); //get second bezier curve point
            this.transform.position = Vector3.Lerp(curve1, curve2, ThrowStep); //lerp between two points
        }
    }

    // Rotates the cube as it is being thrown
    private void AnimateCubeRotation()
    {
        transform.Rotate(Vector3.Cross(transform.up, transform.right), AnimRotationSpeed); //TODO: Replace the vector with the swipe direction
    }
}
