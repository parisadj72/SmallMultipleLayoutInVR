using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPrefabInstantiatingScript : MonoBehaviour
{
    public GameObject modelPrefab;
    public GameObject dockPositionObjectCollection;
    public int width = 6;
    public int height = 3;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Dock dock = dockPositionObjectCollection.transform.GetChild(i).GetComponent<Dock>();
                GameObject instantiatedClone = Instantiate(modelPrefab, dock.transform.position, 
                    Quaternion.identity, this.transform);
                instantiatedClone.GetComponent<Dockable>().Dock(dock.transform.GetChild(0).GetComponent<DockPosition>());
                //dockPositionPrefab.GetComponentInChildren<DockPosition>().DockedObject = modelPrefab.GetComponent<Dockable>();
                //dockPositionPrefab.transform.GetChild(0).GetComponent<DockPosition>().DockedObject = modelPrefab.GetComponent<Dockable>();
                //dockPositionObjectCollection.transform.GetChild(i).GetChild(0).
                        //GetComponent<DockPosition>().DockedObject = instantiatedClone.GetComponent<Dockable>();
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
