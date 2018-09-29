using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Platform"))
        {
            if (CanStepOnPlatform(other.gameObject))
            {
                //TODO: Lose screen
            }
        }
    }

    bool CanStepOnPlatform(GameObject Platform)
    {
        //if (Platform.GetComponent<PlatformScript>().isFilled)
        //{
        //    return true;
        //}
        return false;
    }

}
