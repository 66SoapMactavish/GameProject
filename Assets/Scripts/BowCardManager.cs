using CardSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowCardManager: MonoBehaviour
{
    public static BowCardManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    //��������
    public int BowNum = 5;

    //�����ı�
    [SerializeField]private Text BowText;

    public BowCardManager(Text text)
    {
        this.BowText = text;
    }

    public void PickUpCard(Card card)
    {
        if (card.getName().Equals("Bow"))
        {
            this.BowNum++;

        }
        updateText();

    }
    //isRelease���Ƿ�Ҫ�ͷż���
    public void UseCard(bool isRelease)
    {


        Button button = GetComponent<Button>();
        if (button.tag == "BowCard")
        {
            Debug.Log("bow --");
            if (this.BowNum > 0)
            {
                this.BowNum--;
                if (isRelease)
                {
                    useBow(UpgradeBowCard.Instance.isUpgraded);

                }

            }

        }

        updateText();


    }

    public void getUpdated()
    {
        GetComponent<Image>().color = Color.blue;
    }

    public void updateText()
    {
        this.BowText.text = this.BowNum.ToString();
    }

    //ʹ�ù���Ч��
    private void useBow(bool isUpgraded)
    {
        if (isUpgraded)
        {//��������
            GetComponent<Image>().color = new Color(255, 255, 255);
            UpgradeBowCard.Instance.DownGradeBow();
            //TODO
        }
        else
        {//����ͨ��
            //TODO
        }
        return;
    }
}
