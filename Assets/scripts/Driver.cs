using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
public class Driver : MonoBehaviour
{
    [SerializeField] float currentspeed = 5f;
    [SerializeField] float steerspeed = 2f;
    [SerializeField] float boostspeed = 10f;
    [SerializeField] float regularspeed = 5f;

    [SerializeField] TMP_Text BOOSTTEXT;
    private void Start()
    {
        BOOSTTEXT.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boost"))
        {
            currentspeed = boostspeed;
            BOOSTTEXT.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("worldcollision"))
        {
            currentspeed = regularspeed;
            BOOSTTEXT.gameObject.SetActive(false);
        }
    }   
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            steer=1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            steer=-1f;
        }

        float moveamount = move * currentspeed * Time.deltaTime;
        float steeramount = steer * steerspeed * Time.deltaTime;
        transform.Translate(0f, moveamount , 0);
        transform.Rotate(0, 0, steeramount );
            
        
    }
 }
