using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))] // tự thêm collider nếu như chưa có

public abstract class Brick: MonoBehaviour
{
    //[SerializeField] private Renderer brickRenderer;
    [SerializeField] private Material normalBrickMaterial;
    public void OnTriggerExit(Collider other){
        gameObject.tag = "Walkable";
        //brickRenderer.material = normalBrickMaterial;
    }
}