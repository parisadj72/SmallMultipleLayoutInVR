using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DockHandlerScript : MonoBehaviour
{
    public BoundingBox bbox;
    private Color newColour = Color.white;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<DockPosition>().IsOccupied)
        {
            if (this.GetComponent<DockPosition>().DockedObject.CanUndock)
            {
                bbox.WireframeEdgeRadius = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        bbox.WireframeEdgeRadius = 0.007f;
        bbox.WireframeMaterial.SetColor("_Color", newColour);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        bbox.WireframeEdgeRadius = 0;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
