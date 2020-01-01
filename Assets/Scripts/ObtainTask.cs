using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObtainTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Receipt receipt = ReceiptManager.GetInstance().receipts[0];
        GameObject receiptTitle= GameObject.FindGameObjectWithTag("receiptTitle");
        receiptTitle.transform.position = new Vector3(Screen.width - 20, Screen.height - 20);

        UnityEngine.UI.Text title = receiptTitle.GetComponent<UnityEngine.UI.Text>();
        title.text = receipt.TitleProp.ToString();


        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        print(ReceiptManager.GetInstance().receipts[0].IngredientsProperty[0].TitleProp);


        int counter = 1;
        foreach (var item in receipt.IngredientsProperty)
        {
            print(item.TitleProp);
            print(item.AmountProperty);


            GameObject gameObject = new GameObject(item.TitleProp);
            gameObject.transform.SetParent(this.transform);

            gameObject.AddComponent<UnityEngine.UI.Text>().text = item.TitleProp + " / " + item.AmountProperty + " ml";
            UnityEngine.UI.Text text = gameObject.GetComponent<UnityEngine.UI.Text>();
            text.font = ArialFont;
            text.color = Color.white;

            
            gameObject.transform.position = new Vector3(receiptTitle.transform.position.x - 30,receiptTitle.transform.position.y - (counter*60));
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
