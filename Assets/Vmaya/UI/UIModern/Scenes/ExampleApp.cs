using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vmaya.Scene3D;
using Vmaya.UI.Menu;

public class ExampleApp : MonoBehaviour, ISwitchable
{
    [SerializeField]
    private List<string> menuItemsAsToggle;

    public void setOn(bool value)
    {
        Debug.Log("������ ������������� ������ � ������ ���� -> " + value);
    }

    void Awake()
    {
        MenuItemToggle.actionToggleList = menuItemsAsToggle;
    }
}
