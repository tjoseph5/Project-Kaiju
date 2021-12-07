using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashVFX : MonoBehaviour
{

    public GameObject waterSplashVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject waterVFX = Instantiate(waterSplashVFX, other.transform.position, other.transform.rotation);
    }
}
