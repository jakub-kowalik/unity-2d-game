using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool isMenuOpen = false;

    public static int Score = 1000;
    public static int Level = 1;
    public static string PlayerName = "Player";

    public static float volume = 1;
    public static int amountOfLevels = 1;
    public static string serverUri = "http://localhost:53198";

    internal static void resetValues()
    {
        isMenuOpen = false;
        Score = 1000;
    }
}
