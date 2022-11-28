using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypePlayer { leafMexico, leafFitnes, leafBigote };


public class PlayerMoveJoyst : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    private Vector3 inicialLocateEscale;
    float cX, contador, xSen;
    public float frecuencia, anchoCiclo;
    private float HorizontalMove = 0f;
    public Joystick joystick;
    public float runspeedHorizontal = 0;
    public CheckGround checkGround;
    [SerializeField] Sprite leafMexicoSprite, leafFitnesSprite, leafBigoteSprite;

    PlayFabManager playFabManager;
    public string friendsTxt;
    public string highfriendsTxt;
    int number;
    public TypePlayer myTypePlayer;
    [SerializeField] NumberFriendsSave numberFriendsSave;
    void Awake()
    {
        playFabManager = GameObject.Find("PlayFabManager").GetComponent<PlayFabManager>();
        //PLAYFAB MANAGER
        if (playFabManager.PlayerSkin == "leafMexico")
        {
            myTypePlayer = TypePlayer.leafMexico;
        }
        if (playFabManager.PlayerSkin == "leafFitnes")
        {
            myTypePlayer = TypePlayer.leafFitnes;
        }
        else
        {
            myTypePlayer = TypePlayer.leafBigote;
        }
        //---------
        switch (myTypePlayer)
        {
            case TypePlayer.leafMexico:
                GetComponent<SpriteRenderer>().sprite = leafMexicoSprite;
                break;
            case TypePlayer.leafFitnes:
                GetComponent<SpriteRenderer>().sprite = leafFitnesSprite;
                break;
            case TypePlayer.leafBigote:
                GetComponent<SpriteRenderer>().sprite = leafBigoteSprite;
                break;
        }
    }
    void Start()
    {
        highfriendsTxt = PlayerPrefs.GetInt("HighFriends", 0).ToString();
        inicialLocateEscale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (HorizontalMove > 0)
        {
            transform.localScale = new Vector3(inicialLocateEscale.x, transform.localScale.y, transform.localScale.z);
            //animator.SetBool("Caminar", true);
        }
        else if (HorizontalMove < 0)
        {
            transform.localScale = new Vector3(-inicialLocateEscale.x, transform.localScale.y, transform.localScale.z);
            //animator.SetBool("Caminar", true);
        }
        else
        {
            //quieto
            //animator.SetBool("Caminar", false);
        }
    }
    void FixedUpdate()
    {

        HorizontalMove = joystick.Horizontal * runspeedHorizontal;
        transform.position += new Vector3(HorizontalMove, 0, 0) * Time.deltaTime * speed;

    }
    private void MovePlayer()
    {
        if (CheckGround.isGrounded)
        {
            contador = contador + (frecuencia / 100);
            xSen = Mathf.Sin(contador);
            rb.velocity = new Vector3(transform.position.x, cX + (xSen * anchoCiclo), transform.position.z);

        }

        /*movement.x=Input.GetAxisRaw("Horizontal");
        spriteRenderer.flipX = movement.x < 0;*/

    }
    public void Salto()
    {
        StartCoroutine(JumpFalse());
        if (checkGround.grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //animator.SetBool("Jump", true);
            Debug.Log("AnimSaltoTrue");
        }
    }
    IEnumerator JumpFalse()
    {
        yield return new WaitForSeconds(1);
        //animator.SetBool("Jump", false);
        Debug.Log("AnimSaltoFalse");

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Friend"))
        {
            numberFriendsSave.AddScore();
            Debug.Log("Colisionconamigo");
        }
    }
}
