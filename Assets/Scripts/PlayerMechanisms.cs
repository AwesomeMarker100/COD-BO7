using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMechanisms : MonoBehaviour
{

    [SerializeField] int maxDamage = 20;
    [SerializeField] Canvas gameOver;
    [SerializeField] Canvas displayHealth;
    [SerializeField] HitEffectChanger ppv;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        ppv = FindObjectOfType<HitEffectChanger>();

        tmp = displayHealth.GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = maxDamage.ToString();

    }



    void Update()
    {

        

    }

    // Update is called once per frame
    public void DecreaseHealth(int damageTaken)
    {
        ppv.StartRoutine();
        maxDamage -= damageTaken;
        tmp.text = maxDamage.ToString();
        if (maxDamage <= 0)
        {

            Debug.Log("Player is big dead." + maxDamage);

            gameOver.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0; //stops time
            this.enabled = false;
            
        }


    }
}

