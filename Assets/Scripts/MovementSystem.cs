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

    public float playSpaceDistance = 0.5f;

     void Start()
    {
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

        if(Mathf.Abs(this.transform.position.x - playSpace.transform.position.x) <= playSpaceDistance &&
            Mathf.Abs(this.transform.position.y - playSpace.transform.position.y) <= playSpaceDistance)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.transform.position = new Vector2(mousePos.x, mousePos.y);
        }

        else
        {
            this.transform.position = new Vector2(resetPos.x, resetPos.y);
        }
    }
  
}
