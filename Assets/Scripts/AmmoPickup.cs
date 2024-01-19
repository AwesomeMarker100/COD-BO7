using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//DONE WITH MY OWN LOGIC
public class AmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AmmoType ammoType;
    [SerializeField] int startValue;
    [SerializeField] int endValue;
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Player")
        {

            collidedWith.GetComponentInChildren<Ammo>().AddAmmoCount(ammoType, Random.Range(startValue, endValue));
            

        }

        Destroy(gameObject);

    }
}
