using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{ 

    [SerializeField] private GameObject brickPrefabs;
    [SerializeField] private Transform stackPoint;
    [SerializeField] private GameObject playerRender;
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private AudioClip pickUpSE;
    //[SerializeField] private Settings settings;
    [SerializeField] private Animator anim;
    private string currentAnimName;
    public static int goldCount = 0;
    private List<GameObject> brickStack;
    private const float BRICK_HEIGHT = 0.3f;

    void Start(){
        OnInit();
    }

    private void OnInit(){
        brickStack = new List<GameObject>();
        goldCount = 0;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Brick"))
        {
            PushToStack();
            if(pickUpSE != null){
                Settings.PlaySoundEffect(pickUpSE);
            }
            ChangeAnim("jump");
        }
        else if (other.CompareTag("Inedible Brick"))
        {
            if(brickStack.Count > 0){
                PopFromStack(other.transform.position);
                ChangeAnim("jump");
            } else {
                gameManager.LoadLosePanel();
            }
        }

        else if (other.CompareTag("Win Block"))
        {
            gameManager.LoadEndPanel();
            PopAllStack(other.transform.position);
            ChangeAnim("victory");
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Brick") || other.CompareTag("Inedible Brick")){
            ChangeAnim("idle");
        }
    }

    private void PushToStack(){
        GameObject brick = Instantiate(brickPrefabs, transform.position, Quaternion.identity, stackPoint);
        brick.transform.Rotate(new Vector3(-90,0,180));
        brickStack.Add(brick);
        sort();
        goldCount += 10;
    }

    private void PopFromStack(Vector3 popPoint){   
        if (brickStack.Count != 0) 
        {
            GameObject brick = brickStack[brickStack.Count - 1];
            brickStack.Remove(brick);
            brick.transform.parent = null;
            brick.transform.position = popPoint;
            playerRender.transform.localPosition = new Vector3(0, brickStack.Count * BRICK_HEIGHT, 0);
        }
    }

    private void PopAllStack(Vector3 popPoint){
        while(brickStack.Count > 0){
            PopFromStack(popPoint);
        }
    }

    private void sort(){
        for (int i = 0;  i < brickStack.Count; i++)
        {
            brickStack[i].transform.localPosition = new Vector3(0, i * BRICK_HEIGHT, 0);
        }
        playerRender.transform.localPosition = new Vector3(0, brickStack.Count * BRICK_HEIGHT, 0);
    }

    //Change anim base on state
    private void ChangeAnim(string animName){
        if(currentAnimName != animName){
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
