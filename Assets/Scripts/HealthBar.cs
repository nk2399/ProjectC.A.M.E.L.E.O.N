using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Sprite[] CarmelHealthSprites;
    public Image CarmelUI;
    private CarmelAngain player;
    private int lifeCounterConvertion;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CarmelAngain>();

    }
    private void Update()
    {
        if (player.lifecounter >= 53f)
        {
            lifeCounterConvertion = 9;
        }
        else if (player.lifecounter >= 47f  && player.lifecounter <= 52 )
        {
            lifeCounterConvertion = 8;
        }
        else if(player.lifecounter >= 41f && player.lifecounter <= 46)
        {
            lifeCounterConvertion = 7;
        }
        else if(player.lifecounter >= 35f && player.lifecounter <= 40)
        {
            lifeCounterConvertion = 6;
        }
        else if(player.lifecounter >= 29f && player.lifecounter <= 34)
        {
            lifeCounterConvertion = 5;
        }
        else if(player.lifecounter >= 23f && player.lifecounter <= 28)
        {
            lifeCounterConvertion = 4;
        }
        else if(player.lifecounter >= 17f && player.lifecounter <= 22)
        {
            lifeCounterConvertion = 3;
        }
        else if(player.lifecounter >= 11f && player.lifecounter <= 16)
        {
            lifeCounterConvertion = 2;
        }
        else if(player.lifecounter >= 5f && player.lifecounter <= 10)
        {
            lifeCounterConvertion = 1;
        }
        else if(player.lifecounter >= 0f && player.lifecounter <= 4)
        {
            lifeCounterConvertion = 0;
        }

        CarmelUI.sprite = CarmelHealthSprites[lifeCounterConvertion];
    }
}