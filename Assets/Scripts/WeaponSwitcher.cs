using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All my own logic, entire script
public class WeaponSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    Weapons[] listOfWeps;
    Weapons currentWeapon;
    int i = 0;

    void Start()
    {
        listOfWeps = FindObjectsOfType<Weapons>();
       
        currentWeapon = listOfWeps[i];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && i < listOfWeps.Length - 1)
        {
            i += 1;
            currentWeapon = listOfWeps[i];

        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f && i > 0)
        {
            i -= 1;
            currentWeapon = listOfWeps[i];

        }

        currentWeapon.gameObject.SetActive(true);

        foreach(Weapons wep in listOfWeps)
        {

            if(wep != currentWeapon)
            {

                wep.gameObject.SetActive(false);

            }

        }


    }
}
