using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StoneTools;

public class CountTimeUseDemo : MonoBehaviour {

    CountTimeModel model1;
    void Start () {
        //计时5秒
        model1 = CountTime.Count(5)
        .OnBegin(delegate
        {
            Debug.Log("开始");
        })
        .OnEnd(delegate {
            Debug.Log("结束");
        })
        .OnStop(delegate {
            Debug.Log("停止");
        })
        //更新，可以指定更新频率
        .OnUpdate(onTimeUpdate);

        model1.Begin();
        model1.Pause();
        model1.Continue();
        model1.Stop();
    }
    // update对应的回调需要有一个float参数
    void onTimeUpdate(float time)
    {
        Debug.Log(time);
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

   

}
