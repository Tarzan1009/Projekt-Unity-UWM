using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public GameObject weaponContainer;
    private GameObject weapon;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        weapon = weaponContainer.GetComponent<WeaponSwitch>().currentWeapon;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = weapon.GetComponent<Shoot>().ammo + "/" + weapon.GetComponent<Shoot>().maxAmmo;
    }
}
