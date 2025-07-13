using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using Random = UnityEngine.Random;

public class BackGroundCreateScript : MonoBehaviour
{
    [SerializeField] private GameObject[] backgrounds;


    public void CreateBackground(Transform parent)
    {
        int randomIndex = Random.Range(0, backgrounds.Length);

        //Vector2 posBackground = new Vector2(parent.position.x + 36.84149f, parent.position.y - 13.28416f);

        GameObject newBackground = Instantiate(backgrounds[randomIndex], parent.position, Quaternion.identity);
        //GameObject newBackground = Instantiate(backgrounds[randomIndex], posBackground, Quaternion.identity);
    }

}
