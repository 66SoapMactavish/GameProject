using CardSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBowCard : MonoBehaviour
{
    public bool isUpgraded;

    public static UpgradeBowCard Instance;



    private void Awake()
    {
        this.isUpgraded = false;

        if (Instance == null)
        {
            Instance = this;
        }

    }
    //������
    public void UpGradeBow()
    {
        if (isUpgraded == false && BowCardManager.Instance.BowNum > 0 && SwordCardManager.Instance.SwordNum > 0)
        {//������
            SwordCardManager.Instance.UseCard(false);
            GetComponent<Image>().color = Color.gray;
            this.isUpgraded = true;

            BowCardManager.Instance.getUpdated();

        }



    }
    //������
    public void DownGradeBow()
    {
        if (isUpgraded == true)
        {
            this.isUpgraded = false;
            GetComponent<Image>().color = new Color(0,222,0,134);
        }

    }
}
