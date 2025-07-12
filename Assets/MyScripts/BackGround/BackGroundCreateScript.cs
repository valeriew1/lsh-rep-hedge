using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCreateScript : MonoBehaviour
{
    [SerializeField] private GameObject background;

    public void CreateBackground(Transform parent)
    {
        Vector2 posBackground = new Vector2(parent.position.x + 36.84149f, parent.position.y - 13.28416f);
        GameObject newBackground = Instantiate(background, posBackground, Quaternion.identity);
    } 


}
