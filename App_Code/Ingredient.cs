using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ingredient
/// </summary>
public class Ingredient
{
    public int id { get; set; }
    public String name { get; set; }
    public double quantity { get; set; }
    public String unitMeasure { get; set; }

    public Ingredient()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}