using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板管理器
/// </summary>
public class UIMgr : Singleton<UIMgr>
{
    //画布，用于指向场景中的画布
    private GameObject canvas;
    //面板，用以存放已打开的画布
    public Dictionary<string, ViewBase> dict;
    //层级，用以存放各个层级所对应的父物体
    private Dictionary<UILayer, Transform> layerDict;

    public UIMgr()
    {
        InitLayer();
        dict = new Dictionary<string, ViewBase>();
    }
   
    //初始化层
    private void InitLayer()
    {
        canvas = GameObject.Find("UIParent");
        if(canvas == null)
        {
            Debug.LogError("ViewMgr.InitLayer fali, canvas is null");
        }
        layerDict = new Dictionary<UILayer, Transform>();
        foreach(UILayer p in Enum.GetValues(typeof(UILayer)))
        {
            //场景中的Canvas下的层级命名方式也要是UILayer
            string name = p.ToString();
            Transform transform = canvas.transform.Find(name);
            layerDict.Add(p, transform);
        }
    }

    //打开面板
    public void OpenView<T>(string skinPath, params object[] args) where T : ViewBase
    {
        //已经打开
        string name = typeof(T).ToString();
        if (dict.ContainsKey(name))
        {
            return;
        }
        //面板脚本
        ViewBase View = canvas.AddComponent<T>();
        View.Init(args);
        dict.Add(name, View);
        //加载皮肤
        skinPath = skinPath != "" ? skinPath : View.skinPath;
        GameObject skin = Resources.Load<GameObject>(skinPath);
        if (skin == null)
        {
            Debug.LogError("ViewMgr.OpenView fail, skin is null, skinPath =" + skinPath);
        }
        View.skin = GameObject.Instantiate(skin);
        //坐标
        Transform skinTrans = View.skin.transform;
        UILayer layer = View.layer;
        Transform parent = layerDict[layer];
        skinTrans.SetParent(parent, false);
        //View的生命周期
        View.OnShowing();
        View.OnShowed();
    }
    
    //关闭面板
    public void CloseView(string name)
    {
        ViewBase View = (ViewBase)dict[name];
        if(View == null)
        {
            return;
        }
        View.OnClosing();
        dict.Remove(name);
        View.OnClosed();
        //销毁皮肤和面板
        GameObject.Destroy(View.skin);
        GameObject.Destroy(View);
    }
}

/// <summary>
/// 分层类型
/// </summary>
public enum UILayer
{
    //面板
    View,
    //提示
    Tip
}