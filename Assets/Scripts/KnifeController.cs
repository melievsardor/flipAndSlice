using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider knifeHead;

    [SerializeField]
    private Vector3 delta = new Vector3(2f, 0f,  0f);

    [SerializeField]
    private float force = 5;

    [SerializeField]
    private float torqu = 5f;

    private float timeWhenWeStartedFlying;

    private Rigidbody rigidbody;

    private bool isDown = false;
    private bool isFinish = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (isFinish || !GameManager.Instance.IsPlay)
            return;


        if(Input.GetMouseButtonDown(0) && !isDown)
        {
            isDown = true;

            rigidbody.isKinematic = false;

            timeWhenWeStartedFlying = Time.time;
            
            rigidbody.AddForce(delta * force, ForceMode.Impulse);
            rigidbody.AddTorque(0f, 0f, -torqu, ForceMode.Impulse);

            StartCoroutine(WaitForDown());
        }
    }

    private IEnumerator WaitForDown()
    {
        yield return new WaitForSeconds(0.5f);

        isDown = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        float timeInAir = Time.time - timeWhenWeStartedFlying;

        if (other.tag == "woodenBlock" && timeInAir > 0.3f)
        {
            rigidbody.isKinematic = true;
        }

        if(other.tag == "finish" && timeInAir > 0.3f)
        {
            isFinish = true;
            GameManager.Instance.GameEnd(GameState.Finish);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float timeInAir = Time.time - timeWhenWeStartedFlying;

        

        if (collision.gameObject.tag == "ground" && !rigidbody.isKinematic && timeInAir >= .05f)
        {
            GameManager.Instance.GameEnd(GameState.GameOver);
            isFinish = true;
        }
        
    }


}
