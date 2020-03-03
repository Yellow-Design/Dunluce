using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTeleport : MonoBehaviour
{
    public Color Active;
    public Color Inactive;

    Teleport t;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        t = Camera.main.GetComponent<Teleport>();
        img = this.GetComponent<Image>();
        img.color = Inactive;
        this.GetComponent<Button>().onClick.AddListener(delegate { TeleportSwitch(); });
    }

    // Update is called once per frame
    void TeleportSwitch()
    {
        t.CanTeleport = !t.CanTeleport;
        if (t.CanTeleport)
            img.color = Active;
        else
            img.color = Inactive;
    }
}
