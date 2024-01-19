using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HitEffectChanger : MonoBehaviour
{
    // Start is called before the first frame update
    PostProcessVolume ppv;
    
    [SerializeField] PostProcessProfile normalProfile;
    [SerializeField] PostProcessProfile newProfile;
    void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile = normalProfile;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRoutine()
    {

        StartCoroutine(ChangeLayer());

    }

    IEnumerator ChangeLayer()
    {
        ppv.profile = newProfile;

        yield return new WaitForSeconds(1.5f);

        ppv.profile = normalProfile;

    }
}
