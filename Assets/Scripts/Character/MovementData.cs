using System.Collections.Generic;
using UnityEngine;

public struct MovementForce
{
    public readonly Vector3 force;
    public readonly float duration;
    public float remainingTime;
    public readonly bool isPersistent;

    public MovementForce(Vector3 force, float duration = 0, bool isPersistent = false)
    {
        this.force = force;
        this.duration = duration;
        this.remainingTime = duration;
        this.isPersistent = isPersistent;
    }
}


public sealed class MovementData
{
    // �����ƶ�����
    public float walkSpeed = 1.2f;
    public float runSpeed = 1f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;

    public Vector2 moveInput;
    public bool isJumpPressed;
    public bool isRunPressed;

    // ��ǰ״̬
    public Vector3 moveDirection;
    public Vector3 velocity;
    public bool isGrounded;
    public bool isJumping;

    // ��������
    public float moveBlend;
    public bool isRunning;

    // ����ϵͳ
    private List<MovementForce> forces = new List<MovementForce>();

    public void AddForce(Vector3 force, float duration = 0, bool isPersistent = false)
    {
        forces.Add(new MovementForce(force, duration, isPersistent));
    }

    public void RemoveForce(int index)
    {
        if (index >= 0 && index < forces.Count)
        {
            forces.RemoveAt(index);
        }
    }

    public Vector3 CalculateTotalForce(float deltaTime)
    {
        Vector3 totalForce = Vector3.zero;

        for (int i = forces.Count - 1; i >= 0; i--)
        {
            MovementForce force = forces[i];

            // �ۼ���
            totalForce += force.force;

            if (!force.isPersistent)
            {
                // ���³���ʱ��
                force.remainingTime -= deltaTime;
                forces[i] = force;

                // �Ƴ��ѹ��ڵ���
                if (force.remainingTime <= 0)
                {
                    forces.RemoveAt(i);
                }
            }
        }

        return totalForce;
    }

    public void ClearNonPersistentForces()
    {
        forces.RemoveAll(f => !f.isPersistent);
    }

    public void Reset()
    {
        moveInput = Vector2.zero;
        isJumpPressed = false;
        isRunPressed = false;
        moveDirection = Vector3.zero;
        moveBlend = 0f;
        isJumping = false;
    }
}