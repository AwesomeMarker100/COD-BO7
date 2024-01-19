using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Start is called before the first frame update
    Camera camera;
    [SerializeField] float range = 100f;
    [SerializeField] int weaponDMG = 5;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Canvas canva;
    TextMeshProUGUI tmp;

    bool canShoot = true;
    Ammo am;
    [SerializeField] float timeBetweenShots = 0.5f;
    // Update is called once per frame

    void Start()
    {
        camera = GetComponentInParent<Camera>();
        am = GetComponentInParent<Ammo>();
        tmp = canva.GetComponentInChildren<TextMeshProUGUI>();


    }
    void Update()
    {
        CheckIfMouseDown();
        tmp.text = am.ReturnAmmoCount(ammoType).ToString();

    }

    private void OnEnable()
    {

        canShoot = true;

    }

    void CheckIfMouseDown()
    {

        if (Input.GetMouseButtonDown(0) && am.ReturnAmmoCount(ammoType) > 0 && canShoot)
        {

            StartCoroutine(Fire());

        }
        else
        {

            return;

        }

    }

    IEnumerator Fire()
    {
        canShoot = false;

        MuzzleFlashIt();
        RaycastIt();
        am.DecreaseAmmoCount(ammoType);
        

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void MuzzleFlashIt()
    {

        muzzleFlash.Play();

    }

    private void RaycastIt()
    {
        RaycastHit hit;
        bool didIhit = Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range);

        if (didIhit)
        {

            print(hit.transform.name);
            GameObject ps = Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
            Destroy(ps, ps.GetComponentInChildren<ParticleSystem>().main.duration);
           

            if (hit.transform.GetComponent<EnemyHealth>() != null)
            {

                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.ReduceHealth(weaponDMG);
            }

        }
        else
        {

            return;

        }
    }
}
 