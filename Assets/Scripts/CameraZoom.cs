using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomed;
    public GameObject weaponSwitcher;
    public GameObject crosshairStandard;
    public GameObject crosshairZoom;
    private Camera thisCamera;
    private float defaultZoom;
    private bool zoomPossible;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = gameObject.GetComponent<Camera>();
        defaultZoom = thisCamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        zoomPossible = weaponSwitcher.GetComponent<WeaponSwitch>().zoomPossible;

        if (Input.GetMouseButtonDown(1) && zoomPossible)
        {
            thisCamera.fieldOfView = zoomed;
            crosshairStandard.SetActive(false);
            crosshairZoom.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1) || !zoomPossible)
        {
            thisCamera.fieldOfView = defaultZoom;
            crosshairStandard.SetActive(true);
            crosshairZoom.SetActive(false);
        }
    }
}
