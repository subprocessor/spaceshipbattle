using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    private Rigidbody2D rb;

    float maxVelocity = 3;

    public float rotationSpeed = 3;
     

    #region Monobehaviour API
    // Use this for initialization
    private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);
        Rotate(transform,xAxis*rotationSpeed);
    }
    #endregion

    #region Maneuvering API
    
    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x,-maxVelocity,maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x,y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amout)
    {
        t.Rotate(0,0,amout);
    }

    #endregion
}
