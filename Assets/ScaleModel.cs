using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleModel : MonoBehaviour
{
    GameObject spawnedObject;
    Vector3 initialScale;
    Vector3 initialPos;
    Vector3 initialCamPos;
    Vector3 max;
    Slider slider;
    Camera main;

    [SerializeField]
    float maxScale = 1;
    [SerializeField]
    GameObject teleport;

    private void Start()
    {
        slider = this.GetComponent<Slider>();
        max = new Vector3(maxScale, maxScale, maxScale);
        main = Camera.main;
        StartCoroutine(InitSpawnedObject());
    }

    public void AnimateOnSliderChange()
    {
        if (slider.value > slider.maxValue * 0.75f)
            teleport.SetActive(true);
        else
            teleport.SetActive(false);

        if (spawnedObject != null)
        {
            spawnedObject.transform.localScale = Vector3.Lerp(initialScale, max, slider.value);
            spawnedObject.transform.position = initialPos + (new Vector3(main.transform.forward.x * (slider.value * 60), Mathf.Lerp(0f, -2.5f, slider.value), main.transform.forward.z * (slider.value * 60)));
        }
    }

    public void Reset()
    {
        main.transform.parent.position = initialCamPos;
        spawnedObject.transform.position = initialPos;
        spawnedObject.transform.localScale = initialScale;
    }

    IEnumerator InitSpawnedObject()
    {
        while (GameObject.FindGameObjectWithTag("AR Object") == null)
            yield return new WaitForEndOfFrame();
        spawnedObject = GameObject.FindGameObjectWithTag("AR Object");
        initialScale = spawnedObject.transform.localScale;
        initialPos = spawnedObject.transform.position;
        initialCamPos = main.transform.parent.position;
    }
}
