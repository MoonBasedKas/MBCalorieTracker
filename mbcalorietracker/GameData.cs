using Godot;
using Godot.NativeInterop;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

[GlobalClass]
public partial class GameData : Node
{

    /// <summary>
    /// values = [
    ///     Date =  [
    ///             calories
    ///             ]
    /// ]
    /// </summary>
    static Godot.Collections.Dictionary<string, Variant> dict = null;


    /// <summary>
    /// Loads user data
    /// </summary>
    public static void LoadGame()
    {
        if (!FileAccess.FileExists("user://savegame.save"))
        {
            return; // No need to load
        }

        using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);
        string lines = "";

        while (saveFile.GetPosition() < saveFile.GetLength())
        {
            lines += saveFile.GetLine();

        }
        var json = new Json();
        json.Parse(lines);
        dict = new Godot.Collections.Dictionary<string, Variant>((Godot.Collections.Dictionary)json.Data);
    }

    /// <summary>
    /// Saves user data
    /// </summary>
    public static void SaveGame()
    {
        using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);
        saveFile.StoreLine(Json.Stringify(dict));
    }

    /// <summary>
    /// Inserts a new data element.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="calories"></param>
    public static void InsertData(string date, int calories)
    {
        if (!dict.ContainsKey(date))
        {
            var value = new Godot.Collections.Array<int>();
            value.Add(calories);
            dict.Add(date, value);
        }
        else
            dict[date].AsGodotArray().Add(calories);

        SaveGame();
    }

}
