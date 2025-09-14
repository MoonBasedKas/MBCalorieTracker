using Godot;
using System;

public partial class Home : Node2D
{

    TextEdit input = null;
    TextEdit meal = null;
    RichTextLabel output = null;
    public override void _Ready()
    {
        input = (TextEdit)GetNode("Input");
        output = (RichTextLabel)GetNode("Output");
        meal = (TextEdit)GetNode("meal");
        DateTime dt = DateTime.Now.Date;
        GameData.LoadGame();
        output.Text = GameData.GetCaloriesOn(dt.ToString("yyyy/MM/dd")).ToString();
    }

    /// <summary>
    /// When the add button is pressed it'll update the calorie counter.
    /// </summary>
    public void _on_button_pressed()
    {
        // output.Text = "Calories: " + input.Text;
        int value;
        DateTime dt = DateTime.Now.Date;
        string d = dt.ToString("yyyy/MM/dd");
        if (!int.TryParse(input.Text, out value)) return;

        GameData.InsertData(d, value);
        output.Text = GameData.GetCaloriesOn(d).ToString();
    }

    /// <summary>
    /// Saves a meal
    /// 
    /// </summary>
    public void _on_save_pressed()
    {
        meal.Text = "";
        return;
    }

}
