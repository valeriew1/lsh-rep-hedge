using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBackgroundTrigger : MonoBehaviour
{
    [SerializeField] private BackGroundCreateScript backgroundCreate;

    private void Awake()
    {
        backgroundCreate = FindObjectOfType<BackGroundCreateScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            backgroundCreate.CreateBackground(transform.parent);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

}
