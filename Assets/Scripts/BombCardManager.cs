using CardSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCardManager : MonoBehaviour
{
    public static BombCardManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    //��������
    public int BombNum = 5;

    //�����ı�
    [SerializeField] private Text BombText;

    public BombCardManager(Text text)
    {
        this.BombText = text;
    }

    public void PickUpCard()
    {
        this.BombNum++;
        updateText();

    }
    //isRelease���Ƿ�Ҫ�ͷż���
    public void UseCard(bool isRelease)
    {
        if (Player.Instance.player_state == Player.Player_State.Bomb)
        {
            return;
        }

        Button button = GetComponent<Button>();
        if (button.tag == "BombCard")
        {
            Debug.Log("bomb --");
            if (this.BombNum > 0)
            {
                this.BombNum--;
                if (isRelease)
                {
                    useBomb();

                }

            }

        }

        updateText();


    }


    public void updateText()
    {
        this.BombText.text = this.BombNum.ToString();
    }

    //ʹ�ôݻٳǵ�Ч��
    private void useBomb()
    {


         Player.Instance.player_state = Player.Player_State.Bomb;
         //��Ҫ���϶���

        return;
    }
}
