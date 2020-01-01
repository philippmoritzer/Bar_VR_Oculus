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


    public GameObject nextFill;
    public TextMeshPro text;
    public TextMeshPro orderText;

    ReceiptManager mang;

    
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
        

        if (ReceiptManager.GetInstance().receipts[0].done && !mang.recOneFinished)
        {
            print("receipt one is done");
                       
            this.gameObject.transform.position = waitingPinaColade.transform.position;            
            Destroy(this.waitingPinaColade);

            mang.recOneFinished = true;
            this.nextFill.active = true;
            text.text = "Pina Colada\nAccuracy: " + ReceiptManager.GetInstance().receipts[0].result + "%";
            orderText.fontStyle = FontStyles.Strikethrough;

        }
        else if (ReceiptManager.GetInstance().receipts[1].done && !mang.recTwoFinished) {
            print("receipt two is done");


            this.gameObject.transform.position = waitingLongIsland.transform.position;            
            Destroy(this.waitingLongIsland);


            mang.recTwoFinished = true;
            this.nextFill.active = true;
            text.text = "Long Island Ice Tea\nAccuracy: "+ ReceiptManager.GetInstance().receipts[1].result + "%";
            orderText.fontStyle = FontStyles.Strikethrough;
        }
        else if (ReceiptManager.GetInstance().receipts[2].done && !mang.recThreeFinished) {
            print("receipt three is done");
            this.gameObject.transform.position = waitingTequilaSunrise.transform.position;
            Destroy(this.waitingTequilaSunrise);
            mang.recThreeFinished = true;
            text.text = "Tequila Sunrise\nAccuracy: " + ReceiptManager.GetInstance().receipts[2].result + "% ";
            orderText.fontStyle = FontStyles.Strikethrough;
        }
    }
}
