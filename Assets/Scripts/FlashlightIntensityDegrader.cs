using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//my own logic
public class FlashlightIntensityDegrader : MonoBehaviour
{
    // Start is called before the first frame update
    Light light;
    [SerializeField] float waitTime;
    private IEnumerator coroutine;

    void Start()
    {
        light = GetComponent<Light>();
        coroutine = IntensityDegrader();

        StartCoroutine(coroutine);

    }

    // Update is called once per frame
    void Update()
    {

        


    }

    IEnumerator IntensityDegrader()
    {
        while (true)
        {

            yield return new WaitForSeconds(waitTime);
            light.intensity -= 0.3f;

        }
        

        
    }

    public void AddVoltage(int howMuch)
    {

        light.intensity += howMuch;

        if(light.intensity > 6)
        {
            light.intensity = 6;

        }

    }
}
