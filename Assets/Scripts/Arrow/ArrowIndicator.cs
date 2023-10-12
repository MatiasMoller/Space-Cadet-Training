using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    public GameObject arrow1;
    public Transform goal1;
    public Transform goal2;
    public Transform goal3;
    public float rotationSpeed;

    public bool playerEnteredTrigger2;
    public bool playerEnteredTrigger3;

    private void Update()
    {
        if (playerEnteredTrigger2)
        {
            Debug.Log("Player entered trigger - Rotating towards Goal 2");
            RotateTowardsGoal2();
        }
        else if (playerEnteredTrigger3)
        {
            Debug.Log("Player entered trigger - Rotating towards Goal 3");
            RotateTowardsGoal3();
        }
        else
        {
            Debug.Log("Player not in trigger - Rotating towards Goal 1");
            RotateTowardsGoal1();
        }
    }

    public void RotateTowardsGoal1()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(goal1.position - transform.position), rotationSpeed * Time.deltaTime);
    }
    public void RotateTowardsGoal2()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(goal2.position - transform.position), rotationSpeed * Time.deltaTime);
    }

    public void RotateTowardsGoal3()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(goal3.position - transform.position), rotationSpeed * Time.deltaTime);
    }
}
