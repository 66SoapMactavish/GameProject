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
    //卡牌数量
    public int BombNum = 5;

    //卡牌文本
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
    //isRelease：是否要释放技能
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

    //使用摧毁城的效果
    private void useBomb()
    {


         Player.Instance.player_state = Player.Player_State.Bomb;
         //需要补上动画

        return;
    }
}
