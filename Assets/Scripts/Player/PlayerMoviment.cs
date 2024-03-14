using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    #region Variaveis Private

    // Movimento do jogador
    private Rigidbody2D rb2D;
    private StatusController statusController;
    private Vector2 direction;

    // Dash
    private float durationDash = .2f;
    private float dashCooldown = 1.5f;
    private bool isDash;
    private bool canDash;

    // Animacoes
    private Animator anim;
    private bool isMoveAnim;

    #endregion

    #region Geral

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        statusController = GetComponent<StatusController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Utilizado para dar o dash no personagem
        if (Input.GetKeyDown(KeyCode.LeftShift) && !canDash)
            StartCoroutine(Dash());
        
        IsDirection();
    }

    private void FixedUpdate()
    {
        MoveController();
    }

    #endregion

    #region Moviment/Dash

    // Faz o jogador se movimentar de acordo com os direcionais WASD
    private void MoveController()
    {
        if (isDash)
            return;

        // Utilizado o movimento do personagem
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

        rb2D.MovePosition(rb2D.position + direction * statusController.moveSpeed * Time.fixedDeltaTime);

        // Utilizado para passar os estados das animacoes
        anim.SetBool("IsMove", direction.magnitude > 0);
        isMoveAnim = direction.magnitude > 0;
    }

    // Utilizado para virar o personagem na direcao do mouse
    private void IsDirection()
    {
        Vector2 newDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        newDirection.Normalize();

        if (isMoveAnim) // Utilizado para fazer as animacoes do movimento olhando para a direcao do mouse
        {
            anim.SetFloat("Move X", newDirection.x);
            anim.SetFloat("Move Y", newDirection.y);
        }
        else // Utilizado para fazer as animacoes de parado na direcao do mouse
        {
            anim.SetFloat("Idle X", newDirection.x);
            anim.SetFloat("Idle Y", newDirection.y);
        }
    }

    private IEnumerator Dash() // Faz o jogador dar o dash que e um movimento na direcao que ele esta indo de acordo com o WASD
    {
        canDash = true;
        isDash = true;

        rb2D.velocity = new Vector2(direction.x * statusController.moveDash * ((statusController.bonusDashMove + 100) / 100), direction.y * statusController.moveDash * ((statusController.bonusDashMove + 100) / 100));
        yield return new WaitForSeconds(durationDash);
        isDash = false;

        yield return new WaitForSeconds(dashCooldown * ((100 - statusController.bonusDasnCooldown)) / 100);
        canDash = false;
    }

    #endregion
}
