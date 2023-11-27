using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Slice : MonoBehaviour
{
    //TODO: TP1 - Unused method/variable
    public Rigidbody2D Rigidbody;
    private Vector3 StartingPoint;
    private bool Chopped = false;
    public float SliceSpeed;
    public enum InputOptions { up, down, left, right } //Options for the user to input
    public InputOptions ArrowPressed; // Variable that stores the key that was pressed

    // Start is called before the first frame update
    void Start()
    {
        StartingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: TP2 - Fix - Clean code
        if (Chopped == true)
        {
            transform.position = transform.position + Vector3.down * SliceSpeed * Time.deltaTime;
            if (transform.position.y < StartingPoint.y)
            {
                transform.position = StartingPoint;
                Chopped = false;
            }
        } else if (Chopped == false)
        {
            //TODO: TP2 - Fix - This is the old InputManager, I failed to notice it on correction, but it is prohibited to be used in this assignment. Fix this for the next one or it will fail automatically.
            // Moves knife when user presses one of the arrows, and remembers which arrow was pressed.
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(0, 0, 0);
                ArrowPressed = InputOptions.up;
                Chopped = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(0, 0, 0);
                ArrowPressed = InputOptions.down;
                Chopped = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(0, 0, 0);
                ArrowPressed = InputOptions.left;
                Chopped = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(0, 0, 0);
                ArrowPressed = InputOptions.right;
                Chopped = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position = StartingPoint;
            Chopped = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position = StartingPoint;
            Chopped = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = StartingPoint;
            Chopped = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = StartingPoint;
            Chopped = false;
        }

    }
}
