using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    Transform target;

    //public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    //[SerializeField] private Vector3 offset; // Typically (0, 0, -10) for 2D

    public float distance = 5.0f;


    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.position;
        target = player.transform;
        //offset.z = -10f;
    }

    void Update()
    {
        //offset.z = -10f;
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //smoothedPosition.z = -10f;
        transform.position = smoothedPosition;

        //if (player != null)
        //{
        //    Vector3 desiredPosition = player.position + offset;
        //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //    transform.position = smoothedPosition;
        //}
    }






    //my try:
    //    [SerializeField] private GameObject cam;
    //    //[SerializeField] private Position player;

    //    [SerializeField] private GameObject player;
    //    public Vector2 offset2;
    //    public float smoothSpeed = 0.125f;
    //    Rigidbody2D rb;


    //    // Start is called before the first frame update
    //    void Start()
    //    {
    //        rb = player.GetComponent<Rigidbody2D>();
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (player != null)
    //        {
    //            Vector2 desiredPosition = rb.position + offset2;
    //            Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
    //            transform.position = smoothedPosition;

    //            // Optional: Make camera always look at player
    //            //transform.LookAt(player);
    //        }
    //    }
    //    ///


    //public Transform player;
    //public Vector3 offset;
    //public Vector2 minBounds;
    //public Vector2 maxBounds;

    //void LateUpdate()
    //{
    //    if (player != null)
    //    {
    //        Vector3 desiredPosition = player.position + offset;

    //        // Clamp camera position within bounds
    //        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
    //        desiredPosition.z = Mathf.Clamp(desiredPosition.z, minBounds.y, maxBounds.y);

    //        transform.position = desiredPosition;
    //    }
    //}

    //private void FixedUpdate()
    //{

    //}
}
