using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   // [HideInInspector]
    public float speed;
    public string horizontalAxisName = "Horizontal";
    public string verticalAxisName = "Vertical";
    [SerializeField]
    private Rigidbody _rigidBody;
    private Transform _transform;
	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody>();

        _transform = transform;

        //TODO: dodati komponentu kroz kod ako je nema
        if (_rigidBody == null) {
            Debug.Log("nema rigidbodya");
        }
	}
	
	// Update is called once per frame
	void Update () {

        float moveH = Input.GetAxisRaw(horizontalAxisName);
        float moveV = Input.GetAxisRaw(verticalAxisName);


        Vector3 direction = new Vector3(moveH, 0.0f, moveV);
        direction.Normalize();

        _rigidBody.AddForce(direction * speed * Time.deltaTime, ForceMode.Force);
        //transform.position += direction * speed * Time.deltaTime; 
        
       // transform.position += Vector3.left * moveH * -1.0f;
        
	}
}
