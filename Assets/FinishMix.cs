using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishMix : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject waitingPinaColade;
    private GameObject waitingLongIsland;
    private GameObject waitingTequilaSunrise;


    public GameObject fill1;
    public GameObject fill2;
    public GameObject fill3;
    public GameObject nextFill;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    public TextMeshPro orderText;

    bool animOneStarted = false;
    bool animTwoStarted = false;
    bool animThreeStarted = false;

    ReceiptManager mang;

    private float speed = 1.0f;


    void Start()
    {
        mang = ReceiptManager.GetInstance();
        waitingPinaColade = GameObject.FindGameObjectWithTag("WaitingPinaColada");
        waitingLongIsland = GameObject.FindGameObjectWithTag("WaitingLongIslandIceTea");
        waitingTequilaSunrise = GameObject.FindGameObjectWithTag("WaitingTequilaSunrise");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;


        if (ReceiptManager.GetInstance().receipts[0].done && !mang.recOneFinished)
        {
            if (!mang.recOneFinished)
            {
                if (!animOneStarted)
                {
                    orderText.fontStyle = FontStyles.Strikethrough;
                    text1.text = "Pina Colada\nAccuracy: " + ReceiptManager.GetInstance().receipts[0].result + "%";
                    StartCoroutine(waitFiveSeconds());
                    animOneStarted = true;

                }
                else
                {


                    if (Vector3.Distance(this.fill1.transform.position, waitingPinaColade.transform.position) < 0.001f)
                    {

                        mang.recOneFinished = true;
                        Destroy(this.waitingPinaColade);

                    }
                    else
                    {
                        this.fill1.transform.position = Vector3.MoveTowards(this.fill1.transform.position, waitingPinaColade.transform.position, step);
                    }
                }
            }

        }

        else if (ReceiptManager.GetInstance().receipts[1].done && !mang.recTwoFinished)
        {

            if (!mang.recTwoFinished)
            {
                if (!animTwoStarted)
                {
                    orderText.fontStyle = FontStyles.Strikethrough;
                    text2.text = "Long Island Ice Tea\nAccuracy: " + ReceiptManager.GetInstance().receipts[1].result + "%";
                    StartCoroutine(waitFiveSeconds());
                    animTwoStarted = true;

                }
                else
                {


                    if (Vector3.Distance(this.fill2.transform.position, waitingLongIsland.transform.position) < 0.001f)
                    {

                        mang.recTwoFinished = true;
                        Destroy(this.waitingLongIsland);

                    }
                    else
                    {
                        this.fill2.transform.position = Vector3.MoveTowards(this.fill2.transform.position, waitingLongIsland.transform.position, step);
                    }
                }
            }


            /* print("receipt two is done");


             this.gameObject.transform.position = waitingLongIsland.transform.position;
             Destroy(this.waitingLongIsland);


             mang.recTwoFinished = true;
             StartCoroutine(waitFiveSeconds());
             text.text = "Long Island Ice Tea\nAccuracy: " + ReceiptManager.GetInstance().receipts[1].result + "%";
             orderText.fontStyle = FontStyles.Strikethrough;*/
        }
        else if (ReceiptManager.GetInstance().receipts[2].done && !mang.recThreeFinished)
        {

            if (!mang.recThreeFinished)
            {
                if (!animThreeStarted)
                {
                    orderText.fontStyle = FontStyles.Strikethrough;
                    text3.text = "Tequila Sunrise\nAccuracy: " + ReceiptManager.GetInstance().receipts[2].result + "% ";
                    StartCoroutine(waitFiveSeconds());
                    animThreeStarted = true;

                }
                else
                {


                    if (Vector3.Distance(this.fill3.transform.position, waitingTequilaSunrise.transform.position) < 0.001f)
                    {

                        mang.recThreeFinished = true;
                        Destroy(this.waitingTequilaSunrise);

                    }
                    else
                    {
                        this.fill3.transform.position = Vector3.MoveTowards(this.fill3.transform.position, waitingTequilaSunrise.transform.position, step);
                    }
                }
                print("receipt three is done");

                /*this.gameObject.transform.position = waitingTequilaSunrise.transform.position;
                Destroy(this.waitingTequilaSunrise);
                mang.recThreeFinished = true;
                text.text = "Tequila Sunrise\nAccuracy: " + ReceiptManager.GetInstance().receipts[2].result + "% ";
                orderText.fontStyle = FontStyles.Strikethrough;*/
            }
        }



    }

    IEnumerator waitFiveSeconds()
    {
        yield return new WaitForSeconds(5);
        this.nextFill.active = true;

    }
}