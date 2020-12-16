using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth_In_Unit = 15f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    //cached references
    GameSession gameSession;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePaddle();
    }

    private void MoveThePaddle()
    { 
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth_In_Unit;
        }
    }

}
