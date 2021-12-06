using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineUI : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;

    public GameObject outlineHolder;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
        outlineRenderer.enabled = true;
    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        outlineObject.transform.localScale = new Vector3(1, 1, 1);

        outlineHolder = outlineObject;

        Renderer rend = outlineObject.GetComponent<Renderer>();

        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineUI>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;

        if(gameObject.tag == "Interactable")
        {
            outlineObject.GetComponent<ThrowableObject>().enabled = false;
            outlineObject.GetComponent<BuoyantObject>().enabled = false;
            outlineObject.GetComponent<Rigidbody>().useGravity = false;
        }

        rend.enabled = false;

        return rend;
    }

    private void OnDisable()
    {
        Destroy(outlineHolder);
    }
}
