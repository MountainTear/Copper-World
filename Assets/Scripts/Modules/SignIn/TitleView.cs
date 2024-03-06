using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 标题界面
/// </summary>
public class TitleView : ViewBase
{
    private Button btn_start;
    private Button btn_info;
    private Button btn_leaderBoard;
    private Button btn_end;

    #region 生命周期
    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "Prefabs/UI/TitleView";
        layer = UILayer.View;
    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = skin.transform;
        btn_start = skinTrans.Find("btn_start").GetComponent<Button>();
        btn_info = skinTrans.Find("btn_info").GetComponent<Button>();
        btn_leaderBoard = skinTrans.Find("btn_leaderBoard").GetComponent<Button>();
        btn_end = skinTrans.Find("btn_end").GetComponent<Button>();

        btn_start.onClick.AddListener(OnStartClick);
        btn_info.onClick.AddListener(OnInfoClick);
        btn_leaderBoard.onClick.AddListener(OnLeaderBoardClick);
        btn_end.onClick.AddListener(OnEndClick);
    }
    #endregion

    public void OnStartClick()
    {
    }

    public void OnInfoClick()
    {
    }

    public void OnLeaderBoardClick()
    {
    }

    public void OnEndClick()
    {
        Application.Quit();
    }
}
