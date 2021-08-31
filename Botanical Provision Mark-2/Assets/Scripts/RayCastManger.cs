using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManger : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private float raylength = 10;
    [SerializeField] private LayerMask newLayerMask;

    [Header("References")]
    [SerializeField] private PlayerVitals playerVitals;
    [SerializeField] private Text itemNameText;



}
