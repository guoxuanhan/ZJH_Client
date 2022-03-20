using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    private InputField input_UserName;
    private InputField input_Password;
    private Button btn_Login;
    private Button btn_Register;

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.ShowLoginPanel, Show);
        Init();
    }

    private void Init()
    {
        input_UserName = transform.Find("input_UserName").GetComponent<InputField>();
        input_Password = transform.Find("input_Password").GetComponent<InputField>();
        btn_Login = transform.Find("btn_Login").GetComponent<Button>();
        btn_Register = transform.Find("btn_Register").GetComponent<Button>();
        btn_Register.onClick.AddListener(OnRegisterButtonClick);
        btn_Login.onClick.AddListener(OnLoginButtonClick);
        gameObject.SetActive(true);
    }
    
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.ShowLoginPanel, Show);
    }

    /// <summary>
    /// 注册按钮点击
    /// </summary>
    private void OnRegisterButtonClick()
    {
        EventCenter.Broadcast(EventDefine.ShowRegisterPanel);
    }

    /// <summary>
    /// 登录按钮点击
    /// </summary>
    private void OnLoginButtonClick()
    {
        if (input_UserName.text == null || input_UserName.text == "")
        {
            Debug.Log("请输入用户名");
            return;
        }
		
        if (input_Password.text == null || input_Password.text == "")
        {
            Debug.Log("请输入密码");
            return;
        }
        
        // TODO
        // 向服务器发送请求登录
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
