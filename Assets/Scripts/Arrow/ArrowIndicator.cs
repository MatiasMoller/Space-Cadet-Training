using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    public GameObject arrow1;
    public Transform goal1;
    public Transform goal2;
    public float rotationSpeed;

    public bool playerEnteredTrigger;

    private void Start()
    {
        playerEnteredTrigger = false;
    }

    public void Update()
    {
        if (playerEnteredTrigger == true)
        {
            Debug.Log("Player entered trigger - Rotating towards Goal 2");
            RotateTowardsGoal2();
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
}
