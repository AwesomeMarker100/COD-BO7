using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AmmoSlot[] ammoSlots; //has list of different types of ammo

    [System.Serializable]
    private class AmmoSlot
    {

        public AmmoType ammoType;
        public int ammoAmmount;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseAmmoCount(AmmoType ammoType)
    {

        AmmoSlot ass = GetAmmoSlot(ammoType); //when weapon calls to decrease ammo amount, will pass in ammo type, decrease specific ammo type 
        ass.ammoAmmount--;


    }

    public int ReturnAmmoCount(AmmoType ammoType)
    {
        AmmoSlot ass = GetAmmoSlot(ammoType);
        return ass.ammoAmmount;

    }

    public void AddAmmoCount(AmmoType ammoType, int ammountToAdd)
    {

        GetAmmoSlot(ammoType).ammoAmmount += ammountToAdd;

    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {

        foreach(AmmoSlot ammoSlot in ammoSlots)
        {

            if(ammoSlot.ammoType == ammoType)
            {

                return ammoSlot;

            }

        }

        return null; 

    }
}
