using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StoneTools;

public class CountTimeUseDemo : MonoBehaviour {

    CountTimeModel model1;
    void Start () {
        model1 = CountTime.Count(5).OnBegin(delegate
        {
            Debug.Log("Begin1");
        }).OnUpdate(onTimeUpdate).OnEnd(delegate {
            Debug.Log("end1");
        }).OnStop(delegate {
            Debug.Log("stop1");
        });
    }

    private void OnGUI()
    {
        if (GUILayout.Button("begin1 5 realtime")) {
            model1.Begin();
        }
        if (GUILayout.Button("stop1"))
        {
            model1.Stop();
        }
        if (GUILayout.Button("Pause1"))
        {
            model1.Pause();
        }
        if (GUILayout.Button("Continue"))
        {
            model1.Continue();
        }
    }

    void onTimeUpdate(float time) {
        Debug.Log(time);
    }

}
