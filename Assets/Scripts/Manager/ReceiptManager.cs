using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiptManager 
{
    private static readonly ReceiptManager instance = new ReceiptManager();
    public List<Receipt> receipts = new List<Receipt>();
    public Receipt activeReceipt;


    public bool recOneFinished = false;
    public bool recTwoFinished = false;
    public bool recThreeFinished = false;
    private ReceiptManager() {
        createReceipts();
        activeReceipt = receipts[0];
    }

    public static ReceiptManager GetInstance() {
        return instance;
    }

    private void createReceipts() {
        List<Ingredient> ingridients = new List<Ingredient>();
        ingridients.Add(new Ingredient("Weißer Rum", 60));
        ingridients.Add(new Ingredient("Ananassaft", 100));
        ingridients.Add(new Ingredient("Kokusnusscreme", 40));
        Receipt r1 = new Receipt("Pina Colada", ingridients);

        List<Ingredient> ingridient2 = new List<Ingredient>();
        ingridient2.Add(new Ingredient("Rum", 25));
        ingridient2.Add(new Ingredient("Vodka", 25));
        ingridient2.Add(new Ingredient("Gin", 25));
        ingridient2.Add(new Ingredient("Tequila", 25));
        Receipt r2 = new Receipt("Long Island Ice Tea", ingridient2);

        List<Ingredient> ingridients3 = new List<Ingredient>();
        ingridients3.Add(new Ingredient("Tequila", 50));
        ingridients3.Add(new Ingredient("Grenadine Sirup", 25));
        ingridients3.Add(new Ingredient("Orange Juice", 175));
        Receipt r3 = new Receipt("Tequila Sunrise", ingridients3);

        receipts.Add(r1);
        receipts.Add(r2);
        receipts.Add(r3);
    }

    public int checkReceiptWinCondition(Receipt receipt, List<int> inputValues) {
        //translate ingridients to MAX_FILING value
        List<int> translatedValues = receipt.translateValues();
        List<int> results = new List<int>();

        int i = 0;
        foreach(var item in inputValues) {
            int expected = translatedValues[i];
            float real = item;
            float temp = 100f / (float)expected;
            float realTo100 = real * temp;
            int ergebnis = (int)Mathf.Round(100f - Mathf.Abs(realTo100 - 100f));
            if (ergebnis < 0) {
                ergebnis = 0;
            }
            results.Add(ergebnis);
            i++;
        }

        int sumAvg = 0;
        foreach (var item in results) {
            sumAvg += item;
        }

        return sumAvg / results.Count;

    }

    public void nextReceipt() {
        
        if ((this.receipts.IndexOf(activeReceipt) + 1) <= 2) { 
            this.activeReceipt = this.receipts[this.receipts.IndexOf(activeReceipt) + 1];
            System.Diagnostics.Debug.WriteLine("AKTIVES REZEPT: " +activeReceipt.TitleProp.ToString());

        }
    }
}
