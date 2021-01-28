using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public bool zoomPossible;
    public GameObject zoomText;
    public GameObject barrettText;
    public GameObject currentWeapon;
    public int currentWeaponNr;
    public GameObject UIWeaponContainer;

    // Start is called before the first frame update
    void Start()
    {
        zoomPossible = false;
        Switch(1);
    }

    void Switch(int weaponNr)
    {
        if (weaponNr > 4)
        {
            weaponNr = 1;
        }
        if (weaponNr < 1)
        {
            weaponNr = 4;
        }
        string weaponName = "";
        string UIWeaponName = "";
        currentWeaponNr = weaponNr;

        switch (weaponNr)
        {
            case 1:
                weaponName = "Handgun";
                UIWeaponName = "UIWeapon1";
                zoomPossible = false;
                barrettText.SetActive(false);
                break;
            case 2:
                weaponName = "Shotgun";
                UIWeaponName = "UIWeapon2";
                zoomPossible = false;
                barrettText.SetActive(false);
                break;
            case 3:
                weaponName = "ColtM4";
                UIWeaponName = "UIWeapon3";
                zoomPossible = true;
                barrettText.SetActive(false);
                break;
            case 4:
                weaponName = "BarrettM107";
                UIWeaponName = "UIWeapon4";
                zoomPossible = true;
                barrettText.SetActive(true);
                break;
        }

        currentWeapon = transform.Find(weaponName).gameObject;

        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        currentWeapon.SetActive(true);

        for (int i = 0; i < transform.childCount; ++i)
        {
            UIWeaponContainer.transform.GetChild(i).gameObject.GetComponent<UnityEngine.UI.Text>().color = Color.gray;
        }
        UIWeaponContainer.transform.Find(UIWeaponName).GetComponent<UnityEngine.UI.Text>().color = Color.white;

        if (zoomPossible)
        {
            zoomText.SetActive(true);
        }
        else
        {
            zoomText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            Switch(currentWeaponNr + 1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Switch(currentWeaponNr - 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Switch(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Switch(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Switch(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Switch(4);
        }
    }
}
