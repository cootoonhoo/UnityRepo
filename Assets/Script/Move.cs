using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{    
    public float velocidade = 10f;
    private float Movimento;
    public float ForcaPulo = 50f;
    private Rigidbody2D rig;
    public Animator animator;

    public bool TaVoando = true;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    Movimento = Input.GetAxis("Horizontal");
    rig.velocity = new Vector2(velocidade * Movimento, rig.velocity.y);
    VirarSprite(Movimento);
    Pulo();

    if(Movimento != 0){
        animator.SetBool("TaCorrendo",true);
        }
    else{
        animator.SetBool("TaCorrendo",false);
        }
    if(!TaVoando && rig.velocity.y == 0){
        animator.SetBool("TaPulando",false);
        }
    }
    
    void Pulo(){
        if(Input.GetButtonDown("Jump") && !TaVoando){
            rig.AddForce(new Vector2(0, ForcaPulo), ForceMode2D.Impulse);
            animator.SetBool("TaPulando",true);
        }
    }

    void OnCollisionEnter2D(Collision2D outroObj){
        if(outroObj.gameObject.CompareTag("Chao")){
            TaVoando = false;
        }
    }
    void OnCollisionExit2D(Collision2D outroObj){
        if(outroObj.gameObject.CompareTag("Chao")){
            TaVoando = true;
        }
    }
    void VirarSprite(float DirecaoMovimento){
        if(DirecaoMovimento >  0){
            gameObject.transform.localScale = new Vector3(1,1,1);
            }
        else if(DirecaoMovimento < 0){
            gameObject.transform.localScale = new Vector3(-1,1,1);
            }
        }
}