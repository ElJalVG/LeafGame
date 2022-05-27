using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public enum Player {Player1, Player2, Player3, Player4, Player5};
    public Player playerSeleccionado;
    public bool enableSelectPlayer;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if(!enableSelectPlayer)
        {
            ChangeSkins();
        }
        else
        {
            switch(playerSeleccionado)
        {
            case Player.Player1:
            spriteRenderer.sprite=playerRenderer[0];
            animator.runtimeAnimatorController=playersController[0];
            break;
            case Player.Player2:
            spriteRenderer.sprite=playerRenderer[1];
            animator.runtimeAnimatorController=playersController[1];
            break;
            case Player.Player3:
            spriteRenderer.sprite=playerRenderer[2];
            animator.runtimeAnimatorController=playersController[2];
            break;
            case Player.Player4:
            spriteRenderer.sprite=playerRenderer[3];
            animator.runtimeAnimatorController=playersController[3];
            break;
            case Player.Player5:
            spriteRenderer.sprite=playerRenderer[4];
            animator.runtimeAnimatorController=playersController[4];
            break;

            default:
            break;
        }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSkins()
    {
        switch(PlayerPrefs.GetString("PlayerSelecionado"))
        {
            case "Player1":
            spriteRenderer.sprite=playerRenderer[0];
            animator.runtimeAnimatorController=playersController[0];
            break;
            case "Player2":
            spriteRenderer.sprite=playerRenderer[1];
            animator.runtimeAnimatorController=playersController[1];
            break;
            case "Player3":
            spriteRenderer.sprite=playerRenderer[2];
            animator.runtimeAnimatorController=playersController[2];
            break;
            case "Player4":
            spriteRenderer.sprite=playerRenderer[3];
            animator.runtimeAnimatorController=playersController[3];
            break;
            case "Player5":
            spriteRenderer.sprite=playerRenderer[4];
            animator.runtimeAnimatorController=playersController[4];
            break;

            default:
            break;
        }
    }
}


