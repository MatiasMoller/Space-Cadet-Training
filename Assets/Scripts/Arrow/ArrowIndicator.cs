using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [Header("Arrow")]
    public GameObject arrow1;

    [Header("Target Gates")]
    public Transform goal1;
    public Transform goal2;
    public Transform goal3;
    public Transform goal4;
    public Transform goal5;
    public Transform goal6;
    public Transform goal7;
    public Transform goal8;
    public Transform goal9;
    public Transform goal10;

    [Header("Variables")]
    public float rotationSpeed;
    public int activeTrigger = 0;

    private void Update()
    {
        switch (activeTrigger)
        {
            default: RotateTowardsGoal(goal10); Debug.Log("Rotating towards Goal 10"); break;
            case 0: RotateTowardsGoal(goal1); Debug.Log("Rotating towards Goal 1"); break;
            case 1: RotateTowardsGoal(goal2); Debug.Log("Rotating towards Goal 2"); break;
            case 2: RotateTowardsGoal(goal3); Debug.Log("Rotating towards Goal 3"); break;
            case 3: RotateTowardsGoal(goal4); Debug.Log("Rotating towards Goal 4"); break;
            case 4: RotateTowardsGoal(goal5); Debug.Log("Rotating towards Goal 5"); break;
            case 5: RotateTowardsGoal(goal6); Debug.Log("Rotating towards Goal 6"); break;
            case 6: RotateTowardsGoal(goal7); Debug.Log("Rotating towards Goal 7"); break;
            case 7: RotateTowardsGoal(goal8); Debug.Log("Rotating towards Goal 8"); break;
            case 8: RotateTowardsGoal(goal9); Debug.Log("Rotating towards Goal 9"); break;
            case 9: RotateTowardsGoal(goal10); Debug.Log("Rotating towards Goal 10"); break;
        }
    }

    public void RotateTowardsGoal(Transform activeGoal)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(activeGoal.position - transform.position), rotationSpeed * Time.deltaTime);
    }
}