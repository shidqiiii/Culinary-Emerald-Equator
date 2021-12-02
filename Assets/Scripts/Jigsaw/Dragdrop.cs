using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragdrop : MonoBehaviour
{
    public GameObject detector;
    public Vector3 scaleAwal, randomPos;
    public bool onPos = false, onTempel = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-0.35f, 0.35f), -4.19f);

        randomPos = transform.position;

        scaleAwal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        if (!onTempel)
        {
            Vector3 posMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            transform.position = new Vector3(posMouse.x, posMouse.y, -1);
            if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2")
            {
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 4")
            {
                transform.localScale = new Vector2(.8f, .8f);
            }
            else if (SceneManager.GetActiveScene().name == "Level 5")
            {
                transform.localScale = new Vector2(.6f, .6f);
            }
        }
    }

    public void OnMouseUp()
    {
        if (onPos)
        {
            transform.position = detector.transform.position;            
            onTempel = true;
        }
        else
        {
            transform.position = randomPos;
            transform.localScale = new Vector2(1f, 1f);
            onTempel = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == detector)
        {
            onPos = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == detector)
        {
            onPos = false;
        }
    }
}
