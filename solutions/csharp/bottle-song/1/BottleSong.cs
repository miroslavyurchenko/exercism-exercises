using System.Collections.Generic;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        string[] numbers = {
            "no",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten"
        };

        for (int i = startBottles; i > startBottles - takeDown; i--){

            string currentBottle = i == 1 ? "bottle" : "bottles";
            
            yield return $"{numbers[i]} green {currentBottle} hanging on the wall,";
            yield return $"{numbers[i]} green {currentBottle} hanging on the wall,";
            yield return $"And if one green bottle should accidentally fall,";
        
            string bottle = i - 1 == 1 ? "bottle" : "bottles";
            yield return $"There'll be {numbers[i - 1].ToLower()} green {bottle} hanging on the wall.";

            if (i > startBottles - takeDown + 1){
                yield return "";
            }
        }
    }
}