// ========================================================
// 描 述：
// 作 者：xzf 
// 创建时间：2017/12/07 14:43:28
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public Text Msg;

	void Start () {
        Application.logMessageReceived += Application_logMessageReceived;
	}

    private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
    {
        Msg.text = condition + ":" + stackTrace + ":" + type;
    }

    int i = 0;
    void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log(i++);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.LogWarning(i++);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.LogError(i++);
        }
    }
}
