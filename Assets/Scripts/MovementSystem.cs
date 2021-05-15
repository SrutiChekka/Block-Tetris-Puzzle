using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public GameObject playSpace;
    private bool isMoving;

    private float startPosX;
    private float startPosY;

    private Vector2 resetPos;

    public float playSpaceDistanceX = 0.5f;
    public float playSpaceDistanceY = 0.5f;

    private Rigidbody2D rb2D;

     void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        resetPos = this.transform.position;
    }

    void Update()
    {
        if(isMoving)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosX = mousePos.y - this.transform.position.y;

            isMoving = true;
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;

        if(Mathf.Abs(this.transform.position.x - playSpace.transform.position.x) <= playSpaceDistanceX &&
            Mathf.Abs(this.transform.position.y - playSpace.transform.position.y) <= playSpaceDistanceY)
        {
            this.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        }

        else
        {
            this.transform.position = new Vector2(resetPos.x, resetPos.y);
        }
    }
}