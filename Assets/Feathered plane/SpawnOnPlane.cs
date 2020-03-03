using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnOnPlane : MonoBehaviour
{
    public GameObject ToSpawn;
    public string TagToSpawnOn;
    public float yOffset;
    bool spawned = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; // Declare a place for a raycast hit, this is more for readbility than anything
        if (!spawned) // if the AR object hasn't been spawned yet (AR objects should be tagged accordingly)
        {
            if (Input.touchCount > 0) // if the user has tapped the screen
                // Simple raycast. We take the touch point on the screen and convert it to ray and output the data into the raycast hit
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit)) 
                    if (hit.collider.tag.Equals ("AR Plane")) // If it hits an AR plane
                        Spawn(hit.point); // Spawn at the point the user tapped
        }
    }

    void Spawn(Vector3 point)
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("AR Plane")) // Destroy all the planes
            Destroy(g);
        Destroy(this.GetComponent<ARPlaneManager>()); // make sure no more planes spawn
        GameObject temp = Instantiate(ToSpawn, point + Vector3.up * yOffset, Quaternion.identity); // spawn the prefab. The yOffset just moves it up and down from the plane
        spawned = true; // object is spawned now this will no longer do anything. Coould probably just destroy this script if anything...
    }
}
