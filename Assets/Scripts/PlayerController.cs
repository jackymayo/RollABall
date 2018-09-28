using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float speed;
	public float ricochetSpeed;
    public Text countText;
    public Text winText;

    public int numOfPickUps;
    private Rigidbody rb;
    private int count;
    private IList<GameObject> listOfInactivePickUps = new List<GameObject>();
    void RestartGame()
    {
        // All text transformations
        count = 0;
        SetCountText();
        winText.enabled = false;
        // All player transformations
        this.transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        for (int i = 0; i < listOfInactivePickUps.Count; i++){
            listOfInactivePickUps[i].SetActive(true);
        }
    }

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "You Win!";
        winText.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp("r"))
        {

            RestartGame();
        }
    }
    void FixedUpdate()
    {
		if (rb.transform.position.y <= -5) {
			RestartGame();
		}
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Death")) {
			RestartGame();
		}
			
        if (other.gameObject.CompareTag("Pick Up"))
        {
            listOfInactivePickUps.Add(other.gameObject);
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
		if (other.gameObject.CompareTag("Ricochet")) {
			rb.AddForce (new Vector3 (0, ricochetSpeed, 0));
		}
        if (count >= numOfPickUps)
        {	
            winText.enabled = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

}