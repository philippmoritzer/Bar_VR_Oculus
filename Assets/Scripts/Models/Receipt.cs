using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receipt 
{
    public bool done = false;
    public int result = -1;
    
    public Receipt(string title, List<Ingredient> ingredients) {
        this.title = title;
        this.ingredients = ingredients;
    }

    private string title;

    public string TitleProp
    {
        get { return title; }
        set { title = value; }
    }

    private List<Ingredient> ingredients;

    public List<Ingredient> IngredientsProperty
    {
        get { return ingredients; }
        set { ingredients = value; }
    }

    public float getSum() {
        int sum = 0;
        foreach (var item in this.ingredients) {
            sum += item.AmountProperty;
        }
        return (float)sum;
    }

    public List<int> translateValues() {
        List<int> translatedValues = new List<int>();
        foreach (var item in this.ingredients) {
            float percentage = (float)item.AmountProperty / getSum();
            translatedValues.Add((int)Mathf.Round(Constants.MAX_FILING * percentage));
        }
        return translatedValues;
    }
}
