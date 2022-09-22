using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnVisualizationsInLayout : MonoBehaviour
{
    private int modelToSpawnIndex = 0;
    private int timeframecount = 2;
    private int b = 0;
    private bool boolianVar = true;

    /*("pi_00235.sr3", "/StreamingAssets/punq_infill_00235.sr3"),
     * ("pi_00240.sr3", "/StreamingAssets/punq_infill_00240.sr3"),
     * ("pi_00241.sr3", "/StreamingAssets/punq_infill_00241.sr3"),
     * ("pi_00280.sr3", "/StreamingAssets/punq_infill_00280.sr3"),
     * ("pi_00285.sr3", "/StreamingAssets/punq_infill_00285.sr3"),*/
    private List<string> uncertaintyFilePaths = new List<string> { "/StreamingAssets/punq_infill_00235.sr3", "/StreamingAssets/punq_infill_00240.sr3", "/StreamingAssets/punq_infill_00241.sr3", "/StreamingAssets/punq_infill_00280.sr3", "/StreamingAssets/punq_infill_00285.sr3" };
    //private List<string> uncertaintyFilePaths = new List<string> { "/StreamingAssets/mxspr010.sr3", "/StreamingAssets/punq_infill_00235.sr3" };


    public List<Guid> buttonDataSetIDs;

    private int visLoadingCounter = -1;
    public int totalNumOfLoadedViz = 15;
    public int instancesPerVisualization = 3;
    void Start()
    {
        //waitAFrame();
        //DataVizSpawner.Instance.spawnedDataViz.GetComponent<DataVizInfoRef>().FinishedLoadingVizDataEvent.AddListener(func);

    }
    /*private void func()
    {
        string sourceDirectory = Application.dataPath;
        foreach (string uncertaintyFilePath in uncertaintyFilePaths)
        {
            string uncertaintyFilePath2 = sourceDirectory + uncertaintyFilePath;
            foreach (KeyValuePair<Guid, DataSetVizListPair> dataSetVizListPair in MasterVizRef.Instance.AllDataSetVizListPairs)
            {
                string filepath = dataSetVizListPair.Value.DataSet.filepath;
                if (uncertaintyFilePath2 == filepath)
                {
                    Debug.Log("filepathhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh: " + filepath);
                    Dock dock = this.transform.GetChild(modelToSpawnIndex).GetComponent<Dock>();

                    DataVizSpawner.Instance.SpawnOrToggleOnDataVisualization(dataSetVizListPair.Key, Guid.Empty);
                    Transform t = DataVizSpawner.Instance.spawnedDataViz.transform.GetChild(0);
                    t.localScale = t.localScale * 4;

                    t.GetComponent<Dockable>().Dock(dock.transform.GetChild(0).GetComponent<DockPosition>());

                    modelToSpawnIndex++;
                }
            }
        }
    }*/
    private void func(string uncertaintyFilePath)
    {
        string sourceDirectory = Application.dataPath;
        string uncertaintyFilePath2 = sourceDirectory + uncertaintyFilePath;
        foreach (KeyValuePair<Guid, DataSetVizListPair> dataSetVizListPair in MasterVizRef.Instance.AllDataSetVizListPairs)
        {
            string filepath = dataSetVizListPair.Value.DataSet.filepath;
            if (uncertaintyFilePath2 == filepath)
            {
                Debug.Log("filepathhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh: " + filepath);//16
                Dock dock = this.transform.GetChild(modelToSpawnIndex).GetComponent<Dock>();

                DataVizSpawner.Instance.SpawnOrToggleOnDataVisualization(dataSetVizListPair.Key, Guid.Empty);
                Transform t = DataVizSpawner.Instance.spawnedDataViz.transform.GetChild(0);

                /*if (modelToSpawnIndex % 3 == 0)
                { 
                    t.localScale = t.localScale * 4;
                }*/

                t.GetComponent<Dockable>().Dock(dock.transform.GetChild(0).GetComponent<DockPosition>());

                //if (t.GetComponent<Dockable>().CanUndock)
                //if (this.transform.GetChild(modelToSpawnIndex).GetChild(0).GetComponent<DockPosition>().DockedObject == DockingState.Docked)
                //{
                //not printing!
                //Debug.Log("canUndockcanUndockcanUndockcanUndockcanUndockcanUndockcanUndockcanUndock");
                //this.transform.GetChild(modelToSpawnIndex).GetChild(0).GetComponent<BoundingBox>().Active = false;
                //this.transform.GetChild(modelToSpawnIndex).GetChild(0).gameObject.SetActive(false);
                //}

                modelToSpawnIndex++;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //WaitASec(5);
        //waitAFrame();
        /*
        if (boolianVar)
        {
            int i = 0;
            foreach (KeyValuePair<Guid, DataSetVizListPair> dataSetVizListPair in MasterVizRef.Instance.AllDataSetVizListPairs)
            {
                if (uncertaintyFilePaths.Contains(dataSetVizListPair.Value.DataSet.filepath))
                {
                    //Debug.Log("DataSetID: "+ dataSetVizListPair.Key);
                    buttonDataSetIDs[i] = dataSetVizListPair.Key;
                    i++;
                }
            }
            boolianVar = false;
        }

        //spawn 5 for now
        foreach (Guid buttonDataSetID in buttonDataSetIDs)
        {
            if (Time.frameCount == timeframecount)
            {
                Dock dock = this.transform.GetChild(modelToSpawnIndex).GetComponent<Dock>();
                DataVizSpawner.Instance.SpawnOrToggleOnDataVisualization(buttonDataSetID, Guid.Empty);
                Transform t = DataVizSpawner.Instance.spawnedDataViz.transform.GetChild(0);
                t.localScale = t.localScale * 4;
                t.GetComponent<Dockable>().Dock(dock.transform.GetChild(0).GetComponent<DockPosition>());
                modelToSpawnIndex++;

                timeframecount++;

                buttonDataSetIDs.Remove(buttonDataSetID);
                //waitAFrame();
            }
        }
        */

        if (visLoadingCounter < totalNumOfLoadedViz)
        {
            if (visLoadingCounter >= 0)
            {
                func(uncertaintyFilePaths[visLoadingCounter / instancesPerVisualization]);
            }
            visLoadingCounter++;
        }

       /* func("/StreamingAssets/punq_infill_00235.sr3");

        foreach (string uncertaintyFilePath in uncertaintyFilePaths)
        {
            if (Time.frameCount == timeframecount)
            {
                Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");//16
                func(uncertaintyFilePath);
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");//15
                timeframecount++;
                uncertaintyFilePaths.Remove(uncertaintyFilePath);
            }
        }*/

    }
}
