using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSettings : MonoBehaviour {

    [SerializeField]
    private int orientation = 0;

	// Use this for initialization
	void Start () {
        switch (orientation)
        {
            case 0:
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToPortrait = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.orientation = ScreenOrientation.AutoRotation;
                break;
            case 1:
                Screen.orientation = ScreenOrientation.Landscape;
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToPortrait = false;
                Screen.autorotateToPortraitUpsideDown = false;
                Screen.orientation = ScreenOrientation.AutoRotation;
                break;
            default:
                break;
        }
	}
}
