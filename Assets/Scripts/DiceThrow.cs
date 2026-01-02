using UnityEngine;

public class DiceThrow : MonoBehaviour
{
    public float throwForce = 10f;
    public float torqueForce = 5f;
    Rigidbody rb;

    public Transform[] faces; 

    private bool hasStopped = false;
    private float checkDelay = 2f;
    private float timer = 0f;

    public float result;

    public DiceScript diceScript;

    public bool isThrowing = false;

    bool activatedice = false;

    public Rect ClickZone;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        float randomX = Random.Range(-4f, 4f);
        float randomY = 5f;        
        transform.position = new Vector3(randomX, randomY, -4);
        rb.useGravity = false;

        ClickZone = new Rect(400, 100, 1125, 500);
    }

    private void OnGUI()
    {
        GUI.Box(ClickZone, "ClickZone");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isThrowing)
        {            
            hasStopped = false;
            timer = 0f;
            activatedice = true;
        }
        
        if (!hasStopped && rb.IsSleeping() && activatedice)
        {
            result = GetDiceResult();
            Debug.Log("Dice rolled: " + result);
            hasStopped = true;
            isThrowing = false;
            diceScript.SumPoints();
        }
        
        //tarda mes a saber quin numero toca
        /*if (!hasStopped && rb.velocity.magnitude < 0.1f && rb.angularVelocity.magnitude < 0.1f)
        {
            timer += Time.deltaTime;
            if (timer > checkDelay)
            {
                int result = GetDiceResult();
                Debug.Log("Dice rolled: " + result);
                hasStopped = true;
            }
        }*/
    }

    public void ThrowDice()
    {
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(new Vector3(0, 1, 1) * throwForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);

        isThrowing = true;
    }

    int GetDiceResult()
    {
        float maxDot = -1f;
        int faceIndex = -1;

        for (int i = 0; i < faces.Length; i++)
        {
            Vector3 direction = faces[i].up; 
            float dot = Vector3.Dot(direction, Vector3.up);

            if (dot > maxDot)
            {
                maxDot = dot;
                faceIndex = i;
            }
        }
        return faceIndex + 1; 
    }

    public void ResetDice()
    {       
        transform.position = new Vector3(Random.Range(-4f, 4f), 5f, -4); 
        transform.rotation = Quaternion.identity; 
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero; 
        rb.useGravity = false; 
        result = 0;
        hasStopped = false;
    }
}
