using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour 
{
	private InputField input_UserName;
	private InputField input_Password;
	private Button btn_Back;
	private Button btn_Register;
	private Button btn_Pwd;

	private void Awake()
	{
		EventCenter.AddListener(EventDefine.ShowRegisterPanel, Show);
		Init();
	}

	private void Init()
	{
		input_UserName = transform.Find("UserName/input_UserName").GetComponent<InputField>();
		input_Password = transform.Find("Password/input_Password").GetComponent<InputField>();
		btn_Back = transform.Find("btn_Back").GetComponent<Button>();
		btn_Register = transform.Find("btn_Register").GetComponent<Button>();
		btn_Pwd = transform.Find("btn_Pwd").GetComponent<Button>();
		btn_Back.onClick.AddListener(OnBackClick);
		gameObject.SetActive(false);
	}
	
	private void OnDestroy()
	{
		EventCenter.RemoveListener(EventDefine.ShowRegisterPanel, Show);
	}

	/// <summary>
	/// 返回点击按钮
	/// </summary>
	private void OnBackClick()
	{
		gameObject.SetActive(false);
		EventCenter.Broadcast(EventDefine.ShowLoginPanel);
	}
	
	private void Show()
	{
		gameObject.SetActive(true);
	}
}
