using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    GameObject SpotLight;
    [SerializeField]
    Slider slider;
    [SerializeField]
    float TeleportLockTime = 1f;

    [HideInInspector]
    public bool CanTeleport = false;
    bool _TeleportLock = false;
    bool _LastFrameInputFound = false;
    bool _CurrentFrameInputFound = false;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        _CurrentFrameInputFound = (Input.touchCount > 0);

        if (slider.value > 0.75 && CanTeleport && !_TeleportLock)
        {
            if(_CurrentFrameInputFound)
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit, 1000f))
                {
                    SpotLight.SetActive(true);
                    SpotLight.transform.position = hit.point + Vector3.up;
                }

            if(_LastFrameInputFound && !_CurrentFrameInputFound)
            {
                SpotLight.SetActive(false);
                this.transform.parent.position = hit.point + Vector3.up;
                StartCoroutine(HoldTeleport());
            }

        }

        _LastFrameInputFound = (Input.touchCount > 0);
    }

    public IEnumerator HoldTeleport()
    {
        _TeleportLock = true;
        yield return new WaitForSeconds(TeleportLockTime);
        _TeleportLock = false;
    }
}
