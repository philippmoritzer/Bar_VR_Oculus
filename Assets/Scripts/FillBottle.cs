using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FillBottle : MonoBehaviour
{
    public GameObject growObject;
    public GameObject liquid;
    Material[] materials;
    Material mixedMaterial;
    List<Color> ingredients;
    List<int> counter = new List<int>();
    Font ArialFont;
    bool added = false;
    private bool played;

    // Start is called before the first frame update
    void Start()
    {
        played = false;
        materials = Resources.LoadAll<Material>("Materials/");
        ingredients = new List<Color>();
        foreach (var item in ReceiptManager.GetInstance().activeReceipt.IngredientsProperty)
        {
            counter.Add(0);
        }
        counter.Add(0);
        ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
       


    }
    // Update is called once per frame

    void Update()
    {

        bool cirtursFruitAdded = false;


        if (ReceiptManager.GetInstance().activeReceipt.LemonRequiredProp && ReceiptManager.GetInstance().activeReceipt.LimeRequiredProp)
        {
            if (ReceiptManager.GetInstance().activeReceipt.lemonAdded && ReceiptManager.GetInstance().activeReceipt.lemonAdded)
            {
                cirtursFruitAdded = true;
            }
        }
        else if (!ReceiptManager.GetInstance().activeReceipt.LemonRequiredProp && ReceiptManager.GetInstance().activeReceipt.LimeRequiredProp)
        {
            if (ReceiptManager.GetInstance().activeReceipt.limeAdded)
            {
                cirtursFruitAdded = true;
            }
        }
        else if (ReceiptManager.GetInstance().activeReceipt.LemonRequiredProp && !ReceiptManager.GetInstance().activeReceipt.LimeRequiredProp)
        {
            if (ReceiptManager.GetInstance().activeReceipt.lemonAdded)
            {
                cirtursFruitAdded = true;
            }
        }
        else {
            cirtursFruitAdded = true;
        }


        if (counterSum() >= Constants.MAX_FILING && !ReceiptManager.GetInstance().activeReceipt.done && ReceiptManager.GetInstance().activeReceipt.iceAdded && ReceiptManager.GetInstance().activeReceipt.strawAdded && cirtursFruitAdded)
        {
           
                print("IM DOING THIS");

                ReceiptManager mang = ReceiptManager.GetInstance();

                //No other ingridients than the ones needed included
                List<int> viableCounters = new List<int>();
                for (int i = 0; i < counter.Count - 1; i++) {
                    viableCounters.Add(0);
                    viableCounters[i] = counter[i];
                }

          
                int result = ReceiptManager.GetInstance().checkReceiptWinCondition(mang.activeReceipt, viableCounters);
                ReceiptManager.GetInstance().activeReceipt.done = true;
                ReceiptManager.GetInstance().activeReceipt.result = result;

                ReceiptManager.GetInstance().nextReceipt();


                this.counter = new List<int>();
                foreach (var item in ReceiptManager.GetInstance().activeReceipt.IngredientsProperty)
                {
                    counter.Add(0);
                }
                counter.Add(0);
                print(result);

           
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
    
        print("yoyoo");

        string tag = collision.gameObject.tag.Replace("fluid", "");

        if (collision.gameObject.tag.Contains("fluid"))
        {
            if (growObject.transform.localScale.y <= 1)
            {

                                 
                growObject.transform.localScale += new Vector3(0, 0.0025f, 0);

                //Pina Colada
                if (ReceiptManager.GetInstance().activeReceipt == ReceiptManager.GetInstance().receipts[0]) {
                    switch (tag.ToLower())
                    {
                        case "whiterum":
                            counter[0]++;
                            break;
                        case "pineapplejuice":
                            counter[1]++;
                            break;
                        case "coconutjuice":
                            counter[2]++;
                            break;
                        default:
                            counter[3]++;
                            break;
                    }
                }

                //Long Island Ice Tea
                if (ReceiptManager.GetInstance().activeReceipt == ReceiptManager.GetInstance().receipts[1]) {
                    switch (tag.ToLower()) {
                        case "rum":
                            counter[0]++;
                            print("yeye" + counter[0]);
                            break;
                        case "vodka":
                            counter[1]++;
                            break;
                        case "gin":
                            counter[2]++;
                            break;
                        case "tequila":
                            counter[3]++;
                            break;
                        case "limejuice":
                            counter[4]++;
                            break;
                        case "coke":
                            counter[5]++;
                            break;
                        default:
                            counter[6]++;
                            break;
                    }
                }

                //Tequila Sunrise
                if (ReceiptManager.GetInstance().activeReceipt == ReceiptManager.GetInstance().receipts[2]) {
                    switch (tag.ToLower()) {
                        case "tequila":
                            counter[0]++;
                            break;
                        case "grenadinesirup":
                            counter[1]++;
                            break;
                        case "orangejuice":
                            counter[2]++;
                            break;
                        default:
                            counter[3]++;
                            break;
                    }
                   
                }

            
            }



        }

        //liquid.GetComponent<Renderer>().material = materials[0];

        Destroy(collision.collider);



        switch (tag.ToLower())
        {
            case "vodka":
                ingredients.Add(materials[0].color);
                break;
            case "gin":
                ingredients.Add(materials[1].color);
                break;
            case "rum":
                ingredients.Add(materials[2].color);
                break;
            case "whiterum":
                ingredients.Add(materials[3].color);
                break;
            case "pineapplejuice":
                ingredients.Add(materials[4].color);
                break;
            case "coconutjuice":
                ingredients.Add(materials[5].color);
                break;
            case "tequila":
                ingredients.Add(materials[6].color);
                break;
            case "limejuice":
                ingredients.Add(materials[7].color);
                break;
            case "coke":
                ingredients.Add(materials[8].color);
                break;
            case "orangejuice":
                ingredients.Add(materials[9].color);
                break;
            case "grenadinesirup":
                ingredients.Add(materials[10].color);
                break;

        }


        Color mixedColor = CombineColors(ingredients.ToArray());
        createMaterial(mixedColor);


        liquid.GetComponent<Renderer>().material = mixedMaterial;



    }



   





    public static Color CombineColors(params Color[] aColors)
    {
        Color result = new Color(0, 0, 0, 0);
        foreach (Color c in aColors)
        {
            result += c;
        }
        result /= aColors.Length;
        return result;
    }

    private Material createMaterial(Color color)
    {
        mixedMaterial = new Material(Shader.Find("Standard"));
        mixedMaterial.color = color;
        mixedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mixedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mixedMaterial.SetInt("_ZWrite", 0);
        mixedMaterial.DisableKeyword("_ALPHATEST_ON");
        mixedMaterial.DisableKeyword("_ALPHABLEND_ON");
        mixedMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        mixedMaterial.renderQueue = 3000;

        return mixedMaterial;
    }

    private int counterSum()
    {
        int ct = 0;
        foreach (var item in counter)
        {
            ct += item;
        }

        return ct;
    }
}
