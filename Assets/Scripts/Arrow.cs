using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject arrowButtonMove, arrowButtonMoveText, wallMoveOne, wallmoveTwo;
    [SerializeField] GameObject holdText, arrowBox, arrowBoxButton, wallBox;
    [SerializeField] GameObject releaseText, arroyBoxButtonRelease;
    [SerializeField] GameObject enemyText, enemyTextTime, arrowMoveRight;
    [SerializeField] GameObject jumpTex, arrowButtonJump;
    [SerializeField] GameObject wallButtonDoor, arrowButtonOpenDoor, openDoorText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tuto"))
        {
            arrowButtonMove.SetActive(false);
            arrowButtonMoveText.SetActive(false);

        }
        if (other.CompareTag("Tuto"))
        {
            wallMoveOne.SetActive(false);
            wallmoveTwo.SetActive(false);
            arrowMoveRight.SetActive(true);
        }
        if (other.CompareTag("Sujetar"))
        {
            holdText.SetActive(false);
            arrowBox.SetActive(false);
            enemyTextTime.SetActive(false);
            arrowBoxButton.SetActive(false);
            arrowMoveRight.SetActive(false);
            holdText.SetActive(true);
            arrowBoxButton.SetActive(true);
            StartCoroutine(Soltar());
            StartCoroutine(Jump());
        }
        if (other.CompareTag("Enemy"))
        {
            enemyTextTime.SetActive(true);
            StartCoroutine(LetterEnemy());
        }
        if (other.CompareTag("OpenDoor"))
        {
            jumpTex.SetActive(false);
            arrowButtonJump.SetActive(false);
            openDoorText.SetActive(true);
            arrowButtonOpenDoor.SetActive(true);
            StartCoroutine(WallButtonDoor());
        }
    }
    IEnumerator LetterEnemy()
    {
        yield return new WaitForSeconds(3);
        wallBox.SetActive(true);
    }
    IEnumerator Soltar()
    {
        yield return new WaitForSeconds(2);
        releaseText.SetActive(true);
        arroyBoxButtonRelease.SetActive(true);
        holdText.SetActive(false);
        arrowBoxButton.SetActive(false);
        wallBox.SetActive(false);
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(5);
        releaseText.SetActive(false);
        arroyBoxButtonRelease.SetActive(false);
        jumpTex.SetActive(true);
        arrowButtonJump.SetActive(true);
        wallButtonDoor.SetActive(true);
    }
    IEnumerator WallButtonDoor()
    {
        yield return new WaitForSeconds(2);
        wallButtonDoor.SetActive(false);
    }

}
