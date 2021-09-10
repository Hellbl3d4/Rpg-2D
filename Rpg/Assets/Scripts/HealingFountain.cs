using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : Collidable
{
    public int healingAmount = 1;

    private float healColldown = 1.0f;
    private float lastHeal;

    protected override void OnCollide(Collider2D col)
    {
        if(col.name != "Player")
            return;

        if (Time.time - lastHeal > healColldown)
        {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healingAmount);
        }
        
    }
}
