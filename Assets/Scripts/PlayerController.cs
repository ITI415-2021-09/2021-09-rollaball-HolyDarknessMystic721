using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    private Rigidbody rb;
    private int count;
    private int yellowLeft;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; 
        yellowLeft = 12;

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue) {
        //function body
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() {

        countText.text = "You must get 6 points to win. Count: " + count.ToString();

        if(count >= 6) {
            winTextObject.SetActive(true);

        } else if (yellowLeft == 0 & count < 6) {
            loseTextObject.SetActive(true);
        }
    }

    void FixedUpdate() {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("PickUp")) {

        other.gameObject.SetActive(false);
        count = count + 1;
        yellowLeft = yellowLeft -1;

        SetCountText();
        }

        if (other.gameObject.CompareTag("EvilPickUp")) {
        other.gameObject.SetActive(false);
        count = count - 1;

        SetCountText();
        }

    }

}
