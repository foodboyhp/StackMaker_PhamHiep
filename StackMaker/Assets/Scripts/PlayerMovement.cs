using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform checkPointTransform;
    [SerializeField] public Transform playerRender;
    [SerializeField] private float movementSpeed;
    private float threshold = 5f;
    private Vector3 lastMousePosition;
    private Vector3 targetPosition;
    private Transform thisTransform;
    private bool isMove;
    private bool isSwiping;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    private void OnInit(){
        thisTransform = transform;
        targetPosition = thisTransform.position; 
        isMove = false;
        isSwiping = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //Todo: Tối ưu lại để nhân vật không đổi hướng được khi di chuyển
        /*if(Input.GetKeyDown(KeyCode.Mouse0)){
            isSwiping = true;
            lastMousePosition = Input.mousePosition;
            //touchStartPos = Input.mousePosition;
            MouseInputToMove();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            if(isSwiping){
                MouseInputToMove();
                Move();*/

            /*}
            isSwiping = false;
        }*/
        MouseInputToMove();
        Move();
    }

    /*private void FixedUpdate() {
        if(isMove){
            Move();
            //CheckDistance();
        }    
    }

    private void CheckDistance(){
        if(1){
            isMove = false;
        }
    }*/

    private void MouseInputToMove()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //lastMousePosition = Input.mousePosition;
            lastMousePosition = Input.mousePosition;

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {   
            Vector3 playerInput = -(lastMousePosition - Input.mousePosition);
            if (playerInput.magnitude > threshold)
            {

                if (Vector3.Angle(playerInput, Vector3.right) < 45)
                {
                    Raycasting(checkPointTransform.position, Vector3.right);
                    playerRender.rotation = Quaternion.Euler(new Vector3(0,270,0));
                }

                if (Vector3.Angle(playerInput, Vector3.up) < 45)
                {
                    Raycasting(checkPointTransform.position, Vector3.forward);
                    playerRender.rotation = Quaternion.Euler(new Vector3(0,180,0));
                }

                if (Vector3.Angle(playerInput, Vector3.left) <= 45)
                {
                    Raycasting(checkPointTransform.position, Vector3.left);
                    playerRender.rotation = Quaternion.Euler(new Vector3(0,90,0));
                }

                if (Vector3.Angle(playerInput, Vector3.down) <= 45)
                {
                    Raycasting(checkPointTransform.position, Vector3.back);
                    playerRender.rotation = Quaternion.Euler(new Vector3(0,0,0));
                }
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    private void Move()
    {           
        if(!isMove){
            if ((thisTransform.position - targetPosition).sqrMagnitude > 0.001f)
            {
                thisTransform.position = Vector3.MoveTowards(thisTransform.position, targetPosition, movementSpeed * Time.deltaTime);
                isMove = true;
            }   
        }
        else isMove = false; 
    }

    private void Raycasting (Vector3 startRay, Vector3 direction)
    {   
        RaycastHit hit;
       
        if (Physics.Raycast(startRay, direction, out hit, 1f))
        {
            if (hit.transform.CompareTag("Brick") ||
                hit.transform.CompareTag("Inedible Brick") ||
                hit.transform.CompareTag("Walkable") ||
                hit.transform.CompareTag("Win Block"))
            {
                targetPosition.x = hit.transform.position.x;
                targetPosition.z = hit.transform.position.z;
                startRay += direction;
                Raycasting(startRay, direction);
            }
        }
    }
}

