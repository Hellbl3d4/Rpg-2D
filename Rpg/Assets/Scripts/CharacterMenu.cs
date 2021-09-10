﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hitpointText, moedasText, upgradeCosText, xpText;

    // Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character selection
    public void OnArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSelection++;

            // If we went too far away
            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            if(currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            }

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

    // Weapon Upgrade
    public void OnUpdateClick()
    {
        if(GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    // Update the character Information
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprite[GameManager.instance.weapon.weaponLevel];

        if(GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
        {
            upgradeCosText.text = "MAX";
        }
        else
        {
            upgradeCosText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();
        }

        // Meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        moedasText.text = GameManager.instance.moedas.ToString();

        // XP Bar
        int currLevel = GameManager.instance.GetCurrentLevel();

        if (currLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + "total experience points"; // Display total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }
    }
}
