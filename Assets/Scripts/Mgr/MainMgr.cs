using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����̹�����
/// </summary>
public class MainMgr : MonoBehaviour
{
    //����
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
