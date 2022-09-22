using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;

public class SurfaceTypeChanger : MonoBehaviour
{
    public GridObjectCollection gridObjectCollection;

    // Start is called before the first frame update
    void Start()
    {
        if (gridObjectCollection == null)
        {
            gridObjectCollection = GetComponent<GridObjectCollection>();
        }
    }
    public void ChangeSurfaceToPlane()
    {
        if (gridObjectCollection != null)
        {
            gridObjectCollection.SurfaceType = ObjectOrientationSurfaceType.Plane;
        }
    }
    public void ChangeSurfaceToSphere()
    {
        if (gridObjectCollection != null)
        {
            gridObjectCollection.SurfaceType = ObjectOrientationSurfaceType.Sphere;
        }
    }
    public void ChangeSurfaceToCylinder()
    {
        if (gridObjectCollection != null)
        {
            gridObjectCollection.SurfaceType = ObjectOrientationSurfaceType.Cylinder;
        }
    }
}
