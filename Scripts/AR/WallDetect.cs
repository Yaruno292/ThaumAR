using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class WallDetect : MonoBehaviour {

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private Text debugText;
	
	// Update is called once per frame
	void Update () {
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
            TrackableHitFlags.FeaturePointWithSurfaceNormal;

        if (Frame.Raycast(cam.transform.position.x, cam.transform.position.y, raycastFilter, out hit))
        {
            debugText.text = "wall spawn!";
            var wallObj = Instantiate(wallPrefab, hit.Pose.position, hit.Pose.rotation);

            // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
            // world evolves.
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);

            // Andy should look at the camera but still be flush with the plane.
            if ((hit.Flags & TrackableHitFlags.PlaneWithinPolygon) != TrackableHitFlags.None)
            {
                // Get the camera position and match the y-component with the hit position.
                Vector3 cameraPositionSameY = cam.transform.position;
                cameraPositionSameY.y = hit.Pose.position.y;

                // Have Andy look toward the camera respecting his "up" perspective, which may be from ceiling.
                //andyObject.transform.LookAt(cameraPositionSameY, andyObject.transform.up);
            }

            // Make Andy model a child of the anchor.
            wallObj.transform.parent = anchor.transform;
        }
    }
}
