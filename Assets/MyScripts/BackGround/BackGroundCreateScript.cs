using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCreateScript : MonoBehaviour
{
    [SerializeField] private GameObject background;
    //[SerializeField] private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBackground(Transform parent)
    {
        //Vector2 posBackground = new Vector2(parent.position.x + 19.2f, parent.position.y);
        Vector2 posBackground = new Vector2(parent.position.x + 36.84149f, parent.position.y - 13.28416f);
        GameObject newBackground = Instantiate(background, posBackground, Quaternion.identity);
    } 


}
