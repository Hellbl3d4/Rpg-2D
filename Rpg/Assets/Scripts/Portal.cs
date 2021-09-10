using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] scenesNames;

    protected override void OnCollide(Collider2D col)
    {
        if(col.name == "Player")
        {
            // Teleport the player
            GameManager.instance.SaveState();
            string scenesName = scenesNames[Random.Range(0, scenesNames.Length)];
            SceneManager.LoadScene(scenesName);
        }
    }
}
