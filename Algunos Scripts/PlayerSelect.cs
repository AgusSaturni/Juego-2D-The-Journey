﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;

    public enum Player { MaskDude, Frog, VirtualGuy };
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playersRenderer;


        // Start is called before the first frame update
    void Start()
    {

        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.MaskDude:
                    spriteRenderer.sprite = playersRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;
                case Player.Frog:
                    spriteRenderer.sprite = playersRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                case Player.VirtualGuy:
                    spriteRenderer.sprite = playersRenderer[2];
                    animator.runtimeAnimatorController = playersController[2];
                    break;
                default:
                    break;
            }
        }
        
    }

  public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "MaskDude":
                spriteRenderer.sprite = playersRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;
            case "Frog":
                spriteRenderer.sprite = playersRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            case "VirtualGuy":
                spriteRenderer.sprite = playersRenderer[2];
                animator.runtimeAnimatorController = playersController[2];
                break;
            default:
                break;
        }
    }


}