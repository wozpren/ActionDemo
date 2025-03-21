using Animancer;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class IdleState : CharacterMovementBaseState
{
    public TransitionAsset IdleAsset;


    public IdleState(MCharacterController stateMachine) : base(stateMachine) 
    {
        IdleAsset = Addressables.LoadAssetAsync<TransitionAsset>("Assets/Art/Animation/Player/Idle.asset").WaitForCompletion();

    }

    public override void EnterState()
    {
        // �����ƶ���ز���
        movementData.moveDirection = Vector3.zero;
        movementData.moveBlend = 0f;
        movementData.isRunning = false;

        // ���Ŵ�������
        stateMachine.PlayAnimation(animationName: IdleAsset);
    }

    public override void UpdateState()
    {
        // ����ƶ�����

        // ֱ�Ӽ��MovementData�е�����
        if (movementData.moveInput.sqrMagnitude > 0.1f)
        {
            stateMachine.TransitionToState<WalkState>();
            return;
        }

        //if (movementData.isJumpPressed && movementData.isGrounded)
        //{
        //    stateMachine.TransitionToState<PlayerJumpState>();
        //    return;
        //}

        //// �����Ծ����
        //if (Input.GetButtonDown("Jump") && movementData.isGrounded)
        //{
        //    stateMachine.TransitionToState(new PlayerJumpState(stateMachine));
        //    return;
        //}
    }

    public override void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        // �ڴ���״̬�±���ˮƽ�ٶ�Ϊ��
        currentVelocity.x = 0f;
        currentVelocity.z = 0f;

        // ע�⣺��ֱ�ٶ���MovementData�е�����ϵͳ������������
    }

    public override void ExitState()
    {
        // ����״̬�ض�������
    }
}