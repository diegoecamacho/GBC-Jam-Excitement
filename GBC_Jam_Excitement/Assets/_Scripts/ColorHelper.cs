using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GBCJam.ColorValues;

namespace GBCJam
{
    namespace ColorValues
    {
        public class ColorHelper
        {
            /// Adds two colors and returns the combined color
            public static EColor_Value AddColors(EColor_Value Color1, EColor_Value Color2)
            {
                switch (Color1) //check all possible combinations with the first color
                {
                    case EColor_Value.RED:
                        {
                            if (Color2 == EColor_Value.RED) //red + red
                                return EColor_Value.RED;
                            else if (Color2 == EColor_Value.YELLOW) //red + yellow
                                return EColor_Value.ORANGE;
                            else if (Color2 == EColor_Value.BLUE) // red + blue
                                return EColor_Value.PURPLE;

                            break;
                        }
                    case EColor_Value.YELLOW:
                        {
                            if (Color2 == EColor_Value.RED) // yellow + red
                                return EColor_Value.ORANGE;
                            else if (Color2 == EColor_Value.YELLOW) // yellow + yellow
                                return EColor_Value.YELLOW;
                            else if (Color2 == EColor_Value.BLUE) //yellow + blue
                                return EColor_Value.GREEN;
                            
                            break;
                        }

                    case EColor_Value.BLUE:
                        {
                            if (Color2 == EColor_Value.RED) // blue + red
                                return EColor_Value.PURPLE;
                            else if (Color2 == EColor_Value.YELLOW) // blue + yellow
                                return EColor_Value.GREEN;
                            else if (Color2 == EColor_Value.BLUE) //blue + blue
                                return EColor_Value.BLUE;

                            break;
                        }

                    case EColor_Value.NONE:
                        Debug.LogError("Unknown color sent to AddColors");
                        return EColor_Value.NONE;
                }

                Debug.LogError("You are not supposed to reach here.");
                return EColor_Value.NONE;
            }
            
        }

    }
}
