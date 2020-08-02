using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour

{   
    public Rigidbody2D rb;
    public Camera cam;
    private SpriteRenderer sr;
    public Animator anim;
    public GameObject tronoGO;

    public Transform playerTr;
    public GameObject asmodeus;

    private bool trono; 
    private bool coroa;
    private bool capa;
    private bool cetro;

    private Vector2 movementInput;
    public float speed;
    private void Awake()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();   
    }

    private void Start()
    {
        trono = true;
        coroa = false;
        cetro = false;
        capa = false;
    }

    void Update()
    {   
        
        if (coroa && cetro && capa)
        {
            if (trono)
            {
                trono = false;
                tronoGO.SetActive(true);
                StartCoroutine(MensagemFinal());
            }
        }

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (movementInput == Vector2.zero)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("FacingRIGHT", false);
            anim.SetBool("FacingLEFT", false);
            anim.SetBool("FacingUP", false);
            anim.SetBool("FacingDOWN", false);
        }
        if (movementInput.x > 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("FacingRIGHT", true);
            anim.SetBool("FacingLEFT", false);
            anim.SetBool("FacingUP", false);
            anim.SetBool("FacingDOWN", false);
        }
        if (movementInput.x < 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("FacingRIGHT", false);
            anim.SetBool("FacingLEFT", true);
            anim.SetBool("FacingUP", false);
            anim.SetBool("FacingDOWN", false);
        }
        if (movementInput.y > 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("FacingRIGHT", false);
            anim.SetBool("FacingLEFT", false);
            anim.SetBool("FacingUP", true);
            anim.SetBool("FacingDOWN", false);

        }
        if (movementInput.y < 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("FacingRIGHT", false);
            anim.SetBool("FacingLEFT", false);
            anim.SetBool("FacingUP", false);
            anim.SetBool("FacingDOWN", true);
        }


    }

    private void FixedUpdate() {

        rb.velocity = movementInput * speed;
  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NPC")) {
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        if (other.gameObject.CompareTag("Coroa"))
        {
            coroa = true;
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(other.gameObject, 1.5f);
        }
        if (other.gameObject.CompareTag("Cetro"))
        {
            cetro = true;
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(other.gameObject, 1.5f);
        }
        if (other.gameObject.CompareTag("Capa"))
        {
            capa = true;
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(other.gameObject, 1.5f);
        }
        if (other.gameObject.CompareTag("Trono"))
        {
            other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(other.gameObject.GetComponent<DialogueTrigger>(), 1f);
            Asmodeus();
        }
    }
    IEnumerator MensagemFinal()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Asmodeus()
    {
        Instantiate(asmodeus, playerTr.position, playerTr.rotation);
        Destroy(this.gameObject);
    }

}
