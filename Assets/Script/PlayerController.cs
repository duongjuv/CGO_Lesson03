using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum TargerEnum
    {
        TopLeft,
        TopRight,
        BottomLeft, 
        BottomRight
    }
    public float speed;
    // tọa độ các đích đến
    public Transform topLeftTarget;
    public Transform topRightTarget;
    public Transform bottomLeftTarget;
    public Transform bottomRightTarget;

    private Transform currentTarger;
    private TargerEnum nextTarget = TargerEnum.TopLeft; // gán giá trị trạng thái đầu tiên 
    // Start is called before the first frame update
    void Start()
    {
        currentTarger = topLeftTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPossition = currentTarger.position;
        Vector3 moveDirection = targetPossition - transform.position;
        float distance = moveDirection.magnitude;
        if(distance > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarger.position, speed * Time.deltaTime);
        }
        else
        {
            // chưa tới thì chạy tiếp
            saveNextTarget(nextTarget);
        }
        // thay đổi góc quay theo hướng targer obj
        Vector3 direction = currentTarger.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = targetRotation;

    }
    private void saveNextTarget(TargerEnum target)
    {
        switch (target)
        {
            case TargerEnum.TopLeft:
                currentTarger = topLeftTarget;
                nextTarget = TargerEnum.TopRight;
                break;
            case TargerEnum.TopRight:
                currentTarger = topRightTarget;
                nextTarget = TargerEnum.BottomLeft;
                break;
            case TargerEnum.BottomLeft:
                currentTarger = bottomLeftTarget;
                nextTarget = TargerEnum.BottomRight;
                break;
            case TargerEnum.BottomRight:
                currentTarger = bottomRightTarget;
                nextTarget = TargerEnum.TopLeft;
                break;
        }

    }
}
