using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // ������ ��� �������� �����
    public GameObject applePrefab;

    // �������� �������� ������
    private float speed = 10f;

    // ����������, �� ������� ������ ���������� ����������� �������� ������
    private float leftAndRightEdge = 20f;

    // ����������� ���������� ��������� ����������� ��������
    private float chanceToChangeDirections = 0.01f;

    // ������� �������� ����������� �����
    private float secondsBetweenAppleDrops = 1f;
    void Start()
    {
        // ���������� ������ ��� � �������
        Invoke(nameof(DropApple), 2f);
        Invoke(nameof(BoostSpeed), 5f);
    }

    void BoostSpeed()
    {
        if (speed > 0)
            speed += 5;
        else
            speed -= 5;

        if (secondsBetweenAppleDrops > 0.2f)
        {
            secondsBetweenAppleDrops -= 0.05f;
        }
        Invoke(nameof(BoostSpeed), 5f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), secondsBetweenAppleDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // ��������� �����������
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);       // ������ ���� ������
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);      // ������ ���� �����
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
            speed *= -1;
    }
}
