using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    // Start is called before the first frame update
    

    public Ingredient(string title, int amount) {
        this.title = title;
        this.amount = amount;
    }

    private string title;

    public string TitleProp
    {
        get { return title; }
        set { title = value; }
    }

    private int amount;

    public int AmountProperty
    {
        get { return amount; }
        set { amount = value; }
    }



}
