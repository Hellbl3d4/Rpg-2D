using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : Player
{
    public Button MoveYposi, MoveYnega, MoveXposi, MoveXnega;

    protected override void Start()
    {
        MoveYposi = GetComponent<Button>();
        MoveYnega = GetComponent<Button>();

        MoveXposi = GetComponent<Button>();
        MoveXnega = GetComponent<Button>();
    }

    public void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(MoveYposi)
        {
            UpdateMotor(new Vector3(0, y, 0));
        }

        if(MoveYnega)
        {
            UpdateMotor(new Vector3(0, y, 0));
        }

        if(MoveXposi)
        {
            UpdateMotor(new Vector3(x, 0, 0));
        }

        if(MoveXnega)
        {
            UpdateMotor(new Vector3(x, 0, 0));
        }
    }
}
