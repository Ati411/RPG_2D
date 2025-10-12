using UnityEngine;
using UnityEngine.InputSystem;

public class Gatherinput : MonoBehaviour
{
    private Controls myControl;
    public float valueX;
    public bool JumpInput;
    public bool tryAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Awake()
    {
        myControl = new Controls();
    }
    private void OnEnable()
    {
        myControl.Player.Move.performed += StartMove;
        myControl.Player.Move.canceled += StopMove;

        myControl.Player.Jump.performed += JumpStart;
        myControl.Player.Jump.canceled += JumpStop;

        myControl.Player.Attack.performed += AttackStart;
        myControl.Player.Attack.canceled += AttackStop;
        myControl.Player.Enable();
    }
    public void OnDisable()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;
        myControl.Player.Disable();
        //myControl.Disable();
        myControl.Player.Jump.performed -= JumpStart;
        myControl.Player.Jump.canceled -= JumpStop;

        myControl.Player.Attack.performed += AttackStart;
        myControl.Player.Attack.canceled += AttackStop;

        myControl.Player.Disable();
    }
    private void AttackStart(InputAction.CallbackContext ctx)
    {
        tryAttack = true;
    }
    private void AttackStop(InputAction.CallbackContext ctx)
    {
        tryAttack = false;
    }
    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
    }
    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }
    private void JumpStart(InputAction.CallbackContext ctx)
    {
        JumpInput = true;
    }
    private void JumpStop(InputAction.CallbackContext ctx)
    {
        JumpInput = false;
    }
     public void DisableControls()
    {
        myControl.Player.Move.performed -= StartMove;
        myControl.Player.Move.canceled -= StopMove;

        myControl.Player.Jump.performed -= JumpStart;
        myControl.Player.Jump.canceled -= JumpStop;
        
        myControl.Player.Attack.performed += AttackStart;
        myControl.Player.Attack.canceled += AttackStop;

        myControl.Player.Disable();
        valueX = 0;
    }
}
