using CardSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordCardManager : MonoBehaviour
{
    public static SwordCardManager Instance;



    //��������
    public int SwordNum = 5;

    //�����ı�
    [SerializeField] private Text SwordText;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    public SwordCardManager(Text text)
    {
        this.SwordText = text;
    }

    public void PickUpCard()
    {
        this.SwordNum++;
        updateText();

    }
    //isRelease���Ƿ�Ҫ�ͷż���
    public void UseCard(bool isRelease)
    {
        if (Player.Instance.player_state == Player.Player_State.Sword)
        {
            return;
        }

        Button button = GetComponent<Button>();
        if (button.tag == "SwordCard")
        {
            Debug.Log("sword --");
            if (this.SwordNum > 0)
            {
                this.SwordNum--;
                if (isRelease)
                {

                    useSword(UpgradeSwordCard.Instance.isUpgraded);


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
        this.SwordText.text = this.SwordNum.ToString();
    }

    //ʹ�ý���Ч��������Ϊ�Ƿ�Ϊ������
    private void useSword(bool isUpgraded)
    {
        if (isUpgraded)
        {//��������
            GetComponent<Image>().color = new Color(255, 255, 255);
            Player.Instance.player_state = Player.Player_State.Sword;
            UpgradeSwordCard.Instance.DownGradeSword();
            Player.Instance.setAnimeOn("U-SwordOn");

        }
        else
        {//����ͨ��
            Debug.Log("release");
            Player.Instance.player_state = Player.Player_State.Sword;
            Player.Instance.setAnimeOn("SwordOn");
        }
        return;
    }



}
