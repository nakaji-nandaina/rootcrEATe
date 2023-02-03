using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCard : MonoBehaviour
{
    bool exist=false;
    bool rock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNew()
    {
        exist = false;
        rock = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Card"&&exist==true)
        {
            rock = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Card"&&Input.GetMouseButtonUp(0)&&!exist)
        {
            exist = true;
            other.gameObject.transform.position = this.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Card"&&!rock)
        {
            exist = false;
        }
        rock = false;
    }
}
