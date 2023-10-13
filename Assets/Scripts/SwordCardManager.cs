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

    public void PickUpCard(Card card)
    {
        if (card.getName().Equals("Sword"))
        {
            this.SwordNum++;

        }
        updateText();

    }
    //isRelease���Ƿ�Ҫ�ͷż���
    public void UseCard(bool isRelease)
    {


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
            UpgradeSwordCard.Instance.DownGradeSword();
            //TODO

        }
        else
        {//����ͨ��
            Player.Instance.player_state = Player.Player_State.Sword;
         //��Ҫ���϶���
        }
        return;
    }



}
