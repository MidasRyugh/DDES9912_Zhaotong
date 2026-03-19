//EZPZ Interaction Toolkit
//by Matt Cabanag
//created 09 Mar 2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsUtillity : MonoBehaviour
{
    //=====================
    // 原物理功能部分
    //=====================
    public Rigidbody rBody;
    public float forceFactor = 10;
    public float randomComponent = 0;

    //=====================
    // 发动机结构部分
    //=====================
    public GameObject 飞轮, 连接杆;
    public GameObject 活塞;
    public GameObject 大轮;
    public Transform 连接杆和飞轮连接点;
    public Transform 连接杆和活塞连接点;

    [Header("旋转参数")]
    public float 旋转速度 = 100f;
    public float 大轮转速 = 150f;

    public Slider speed; // 速度滑块

    //=====================
    // 初始化
    //=====================
    void Start()
    {
        if (rBody == null)
            rBody = GetComponent<Rigidbody>();

        // 设置滑块范围
        speed.minValue = 100;
        speed.maxValue = 2000;

        // 默认值
        speed.value = 旋转速度;
    }

    //=====================
    // 物理更新（发动机运动）
    //=====================
    void FixedUpdate()
    {
        // 从滑块获取速度（飞轮 = 小轮）
        旋转速度 = speed.value;

        // 大轮速度 = 小轮的 1/2
        大轮转速 = 旋转速度 * 0.5f;

        // 1. 飞轮绕 Z 轴旋转
        if (飞轮 != null)
        {
            飞轮.transform.Rotate(0, 0, 旋转速度 * Time.fixedDeltaTime);
        }

        // 2. 大轮 自己绕 Z 轴自转（是小轮一半）
        if (大轮 != null)
        {
            大轮.transform.Rotate(0, 0, 大轮转速 * Time.fixedDeltaTime);
        }

        // 3. 连接杆位置 = 飞轮连接点位置
        if (连接杆 != null && 连接杆和飞轮连接点 != null)
        {
            连接杆.transform.position = 连接杆和飞轮连接点.position;
        }

        // 4. 活塞只同步 Y 坐标，X Z 完全不动
        if (活塞 != null && 连接杆和活塞连接点 != null)
        {
            Vector3 活塞位置 = 活塞.transform.position;
            活塞位置.y = 连接杆和活塞连接点.position.y;
            活塞.transform.position = 活塞位置;
        }

        // 5. 杆看向活塞
        if (连接杆 != null && 活塞 != null)
        {
            连接杆.transform.LookAt(活塞.transform);
        }
    }

    public void SpinAxis(Vector3 axis, float force)
    {
        rBody.AddRelativeTorque(axis * force * (forceFactor + RandomRoll()));
    }

    public void SpinAxisX(float force)
    {
        SpinAxis(Vector3.right, force);
    }

    public void SpinAxisY(float force)
    {
        SpinAxis(Vector3.up, force);
    }

    public void SpinAxisZ(float force)
    {
        SpinAxis(Vector3.forward, force);
    }

    public void AddForce(Vector3 axis, float force)
    {
        rBody.AddRelativeForce(axis * force * (forceFactor + RandomRoll()));
    }

    public void AddForce(float force)
    {
        AddForceZ(force);
    }

    public void AddForceX(float force)
    {
        AddForce(Vector3.right, force * forceFactor);
    }

    public void AddForceY(float force)
    {
        AddForce(Vector3.up, force * forceFactor);
    }

    public void AddForceZ(float force)
    {
        AddForce(Vector3.forward, force * forceFactor);
    }

    public float RandomRoll()
    {
        return Random.Range(0, randomComponent);
    }
}