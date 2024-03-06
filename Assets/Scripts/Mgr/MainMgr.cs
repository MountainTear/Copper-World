using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主流程管理器
/// </summary>
public class MainMgr : MonoBehaviour
{
    //单例
    public static MainMgr instance;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIMgr.Instance.OpenView<TitleView>("");
    }
}
