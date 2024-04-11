using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{

    [SerializeField] private int speed = 20;

    private void Awake()
    { 
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 moveVec = new Vector2(h, v).normalized;

        transform.Translate(moveVec * speed * Time.deltaTime);
    }
}