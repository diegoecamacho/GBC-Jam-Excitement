using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBCJam
{
    namespace ColorValues
    {
        public class ColorHelper : MonoBehaviour
        {
            private static Color Color_R;
            private static Color Color_Y;
            private static Color Color_B;
            private static Color Color_O;
            private static Color Color_G;
            private static Color Color_P;

            private void Start()
            {
                ColorEnumsToValues enumToColorRef = GameObject.Find("GameManager").GetComponent<ColorEnumsToValues>();
                Color_R = enumToColorRef.Color_R;
                Color_Y = enumToColorRef.Color_Y;
                Color_B = enumToColorRef.Color_B;
                Color_O = enumToColorRef.Color_O;
                Color_G = enumToColorRef.Color_G;
                Color_P = enumToColorRef.Color_P;

            }

            // Adds two colors and returns the combined color
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
            
            // Converts enum to real world color
            public static Color GetRealColor(EColor_Value RequestedColor)
            {
                switch(RequestedColor)
                {
                    case EColor_Value.RED:
                        return Color_R;

                    case EColor_Value.YELLOW:
                        return Color_Y;

                    case EColor_Value.BLUE:
                        return Color_B;

                    case EColor_Value.ORANGE:
                        return Color_O;

                    case EColor_Value.GREEN:
                        return Color_G;

                    case EColor_Value.PURPLE:
                        return Color_P;
                }
                Debug.LogError("You should not reach here");
                return new Color();
            }
        }

    }
}
