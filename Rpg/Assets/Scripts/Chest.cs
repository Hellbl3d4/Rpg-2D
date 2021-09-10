using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount = 0;

    protected override void OnCollect()
    {
       if(!collected)
       {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.moedas += pesosAmount;
            GameManager.instance.ShowText("+" + pesosAmount + " Moedas!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
       }
    }
}
