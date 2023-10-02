using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Keypad : Interactable

{
    MathewHartley.GameManager gameManagerScript;
    [SerializeField] private GameObject door;
    private bool doorOpen;

    // Start is called before the first frame update
    //private void Start()
    //{
    //    gameManagerScript = GameObject.Find("GameManager").GetComponent<MathewHartley.GameManager>();
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (gameManagerScript.killCount == 10)
    //    {

    //    }
    //}

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
