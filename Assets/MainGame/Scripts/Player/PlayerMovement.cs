using System;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour, IPlayerRun
{
    [SerializeField] VariableJoystick joystick;
    [SerializeField] GamePlayUI gamePlayUI;
    [SerializeField] Camera playerCamera;
    [SerializeField] Animator animator;
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float lookSpeed = 2f;
    [SerializeField] float lookXLimit = 45f;
    [SerializeField] float jumpHeight = 3f;
    
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;
    private Vector3 velocity;
    public bool isStop = false;
    private const string animJump = "isJump";
    private const string animRun = "isRun";
    private float limitTouchMove = 1110f;

    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gamePlayUI.onJump=async ()=>{
            if(characterController.isGrounded){
                
                velocity.y = Mathf.Sqrt(jumpHeight * +2f * gravity);
                await Task.Delay(100);
                animator?.SetBool(animJump,true);
            }
        };
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible=false;
    }
    void Update()
    {
        if(isStop) return;
        HandleMove();

    }
    private void HandleMove()
    {
        //Move

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // float curSpeedX = canMove?runSpeed*Input.GetAxis("Vertical"):0;
        // float curSpeedY = canMove?runSpeed*Input.GetAxis("Horizontal"):0;

        float curSpeedX = canMove?runSpeed*joystick.Vertical:0;
        float curSpeedY = canMove?runSpeed*joystick.Horizontal:0;

        moveDirection = (forward*curSpeedX)+(right*curSpeedY);  

        //Rotation

        // if(canMove && Input.GetMouseButton(1)){
        //     rotationX +=Input.GetAxis("Mouse Y")*lookSpeed;
        //     rotationX = Mathf.Clamp(rotationX, -lookXLimit,lookXLimit);
        //     playerCamera.transform.localRotation = Quaternion.Euler(rotationX,0,0);
        //     transform.rotation  *= Quaternion.Euler(0,Input.GetAxis("Mouse X")*lookSpeed,0);
        // }

        // if (canMove && Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);

        //     if (touch.phase == TouchPhase.Moved)
        //     {
        //         float touchDeltaX = touch.deltaPosition.x * lookSpeed * Time.deltaTime;
        //         float touchDeltaY = touch.deltaPosition.y * lookSpeed * Time.deltaTime;

        //         rotationX -= touchDeltaY; // Lật camera lên/xuống
        //         rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //         playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //         transform.rotation *= Quaternion.Euler(0, touchDeltaX, 0); // Quay nhân vật
        //     }
        // }

        HandleRotation();

        HandleJump();

        Vector3 finalMovement = moveDirection + velocity;
        if(moveDirection.magnitude < 0.5f){
            animator?.SetBool(animRun,false);
        }
        else{
            animator?.SetBool(animRun,true);
        }
        characterController.Move(finalMovement * Time.deltaTime);
        
    }
    private void HandleRotation()
    {
        if (canMove && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            // Touch touch1 = Input.GetTouch(1);

            if (touch.phase == TouchPhase.Moved && touch.position.x > limitTouchMove)
            {
                float touchDeltaX = touch.deltaPosition.x * lookSpeed * Time.deltaTime;
                float touchDeltaY = touch.deltaPosition.y * lookSpeed * Time.deltaTime;

                rotationX -= touchDeltaY; 
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            }
            
            if (Input.touchCount > 1)
            {
                Touch touch2 = Input.GetTouch(1); 

                if (touch2.phase == TouchPhase.Moved && touch2.position.x > limitTouchMove)
                {
                    float touchDeltaX = touch2.deltaPosition.x * lookSpeed * Time.deltaTime;
                    float touchDeltaY = touch2.deltaPosition.y * lookSpeed * Time.deltaTime;

                    rotationX -= touchDeltaY; 
                    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                }
            }
        }

        // Nhân vật chỉ quay theo hướng chạm
        if (canMove && Input.touchCount > 0 && Input.GetTouch(0).position.x > limitTouchMove )  
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float touchDeltaX = touch.deltaPosition.x * lookSpeed * Time.deltaTime;
                transform.rotation *= Quaternion.Euler(0, touchDeltaX, 0); 
            }
        }
       
        // if (canMove && Input.touchCount > 0 && Input.GetTouch(1).position.x > limitTouchMove ) 
        // {
        //     Touch touch = Input.GetTouch(1);
        //     if (touch.phase == TouchPhase.Moved)
        //     {
        //         float touchDeltaX = touch.deltaPosition.x * lookSpeed * Time.deltaTime;
        //         transform.rotation *= Quaternion.Euler(0, touchDeltaX, 0); 
        //     }
        // }
    }
    private async void HandleJump()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded){
            
            velocity.y = Mathf.Sqrt(jumpHeight * +2f * gravity);
            await Task.Delay(100);
            animator?.SetBool(animJump,true);
        }
        if (characterController.isGrounded){
            animator?.SetBool(animJump,false);
        }

        velocity.y -= gravity * Time.deltaTime;
    }

    public async void SetPosition(Transform posIn, Transform posOut){
        if(!isStop){
            isStop = true;
            transform.position = posIn.position;
            transform.rotation = posIn.rotation;
        }
        else{
            transform.position = posOut.position;
            transform.rotation = posOut.rotation;
            await Task.Delay(200);
            isStop = false;
        }
        
    }
    // public override void PlayerDead(Vector3 positionBoss){
    //     GamePlayUI.loseGame?.Invoke();
    //     //Look Boss Attack
    //     isStop = true;
    //     animator?.SetBool(animRun,false);
    //     Vector3 dir  = (positionBoss-transform.position).normalized;
    //     dir.y = 0;
    //     Quaternion quaternion = Quaternion.LookRotation(dir);
    //     transform.rotation = quaternion;
    //     Debug.Log("Lose");

    // }

    public void PlayerDead(Vector3 positionBoss)
    {
        GamePlayUI.loseGame?.Invoke();
        //Look Boss Attack
        isStop = true;
        animator?.SetBool(animRun,false);
        Vector3 dir  = (positionBoss-transform.position).normalized;
        dir.y = 0;
        Quaternion quaternion = Quaternion.LookRotation(dir);
        transform.rotation = quaternion;
        Debug.Log("Lose");
    }
}
