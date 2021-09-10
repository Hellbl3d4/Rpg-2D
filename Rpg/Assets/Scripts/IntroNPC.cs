﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroNPC : Collidable
{
    public string message;
    private float cooldown = 4.0f;
    private float lastShout;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }

    protected override void OnCollide(Collider2D col)
    {
        if(Time.time - lastShout > cooldown)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message, 25, Color.white, transform.position + new Vector3(0, 0.25f, 0), Vector3.zero, cooldown);
        }
    }
}
