using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//�̺�Ʈ Ʈ���Ÿ� ���� ����
public class DSController2 : MonoBehaviour
{
    //����� ����� ����� �ؽ�Ʈ
    //TMP ����� ��쿡�� TMP�� ���·� �۾��մϴ�.
    public Text ResultName;
    public Text ResultItemInfo;
    public Text ResultItemExplain;

    public InputField InputName;
    public InputField InputItemInfo;
    public InputField InputItemExplain;


    public void DSListName()
    {
        List<string> name = new List<string>();

        name.Add(InputName.text);
        ResultName.text = InputName.text;
    }

    public void DSListItemInfo()
    {
        List<string> itemInfo = new List<string>();

        itemInfo.Add(InputItemInfo.text);
        ResultItemInfo.text = InputItemInfo.text;
    }

    public void DSListItemExplain()
    {
        List<string> itemExplain = new List<string>();

        itemExplain.Add(InputItemExplain.text);
        ResultItemExplain.text = InputItemExplain.text;
    }

    public void ResultReset()
    {
        ResultName.text = string.Empty;
        ResultItemInfo.text = string.Empty;
        ResultItemExplain.text = string.Empty;
    }
}
