using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JPEG_Recover.Markers;

namespace JPEG_Recover
{
    public class Marker : CompressedFileDataType
    {
        //NOTE: Marker acts as both a supertype and an object factory for subtypes

        public Marker getMarker(byte markerHexCode)
        {
            String markerStringHexCode = markerHexCode.ToString("X");


             if (markerStringHexCode.Equals("01")) 
             {
                 return new TEM();
             }

            
             else if (markerStringHexCode.Equals("C0"))
             {
                 return new SOF_0();
             
             }

             else if (markerStringHexCode.Equals("C1"))
             {
                 return new SOF_1();

             }

             else if (markerStringHexCode.Equals("C2"))
             {
                 return new SOF_2();

             }
             else if (markerStringHexCode.Equals("C3"))
             {
                 return new SOF_3();

             }

             else if (markerStringHexCode.Equals("C4"))
             {
                 return new DHT();
             }

             else if (markerStringHexCode.Equals("C5"))
             {
                 return new SOF_5();
             }

             else if (markerStringHexCode.Equals("C6"))
             {
                 return new SOF_6();
             }
                 
             else if (markerStringHexCode.Equals("C7"))
             {
                 return new SOF_7();
             }

             else if (markerStringHexCode.Equals("C8"))
             {
                 return new JPG();
             }

             else if (markerStringHexCode.Equals("C9"))
             {
                 return new SOF_9();
             }
             
             else if (markerStringHexCode.Equals("CA"))
             {
                 return new SOF_10();
             }
             
             else if (markerStringHexCode.Equals("CB"))
             {
                 return new SOF_11();
             }

             else if (markerStringHexCode.Equals("CC"))
             {
                 return new DAC();
             }


             else if (markerStringHexCode.Equals("CD"))
             {
                 return new SOF_13();
             }

             else if (markerStringHexCode.Equals("CE"))
             {
                 return new SOF_14();
             }

             else if (markerStringHexCode.Equals("CF"))
             {
                 return new SOF_15();
             }



             else if (markerStringHexCode.Equals("D0") ||
                      markerStringHexCode.Equals("D1") ||
                      markerStringHexCode.Equals("D2") ||
                      markerStringHexCode.Equals("D3") ||
                      markerStringHexCode.Equals("D4") ||
                      markerStringHexCode.Equals("D5") ||
                      markerStringHexCode.Equals("D6") ||
                      markerStringHexCode.Equals("D7"))
             {

                 Console.WriteLine(markerStringToSingleDigitDecimal(markerStringHexCode, 1).ToString());
                 return new RST_M();
             }

             else if (markerStringHexCode.Equals("D8"))
             {
                 return new SOI();
             }

             else if (markerStringHexCode.Equals("D9"))
             {
                 return new EOI();
             }

             else if (markerStringHexCode.Equals("DA"))
             {
                 return new SOS();
             }

             else if (markerStringHexCode.Equals("DB"))
             {
                 return new DQT();
             }

             else if (markerStringHexCode.Equals("DC"))
             {
                 return new DNL();
             }


             else if (markerStringHexCode.Equals("DD"))
             {
                 return new DRI();
             }

             else if (markerStringHexCode.Equals("DE"))
             {
                 return new DHP();
             }

             else if (markerStringHexCode.Equals("DF"))
             {
                 return new EXP();
             }


                //E

            //APP_N: FFE0 through FFEF
             else if (markerStringHexCode.Equals("E0") ||
                 markerStringHexCode.Equals("E1") ||
                 markerStringHexCode.Equals("E2") ||
                 markerStringHexCode.Equals("E3") ||
                 markerStringHexCode.Equals("E4") ||
                 markerStringHexCode.Equals("E5") ||
                 markerStringHexCode.Equals("E6") ||
                 markerStringHexCode.Equals("E7") ||
                 markerStringHexCode.Equals("E8") ||
                 markerStringHexCode.Equals("E9") ||
                 markerStringHexCode.Equals("EA") ||
                 markerStringHexCode.Equals("EB") ||
                 markerStringHexCode.Equals("EC") ||
                 markerStringHexCode.Equals("ED") ||
                 markerStringHexCode.Equals("EE") ||
                 markerStringHexCode.Equals("EF"))
             {
                 Console.WriteLine(markerStringToSingleDigitDecimal(markerStringHexCode, 1).ToString());

                 return new APP_N();
             }

             else if (markerStringHexCode.Equals("F0") ||
                     markerStringHexCode.Equals("F1") ||
                     markerStringHexCode.Equals("F2") ||
                     markerStringHexCode.Equals("F3") ||
                     markerStringHexCode.Equals("F4") ||
                     markerStringHexCode.Equals("F5") ||
                     markerStringHexCode.Equals("F6") ||
                     markerStringHexCode.Equals("F7") ||
                     markerStringHexCode.Equals("F8") ||
                     markerStringHexCode.Equals("F9") ||
                     markerStringHexCode.Equals("FA") ||
                     markerStringHexCode.Equals("FB") ||
                     markerStringHexCode.Equals("FC") ||
                     markerStringHexCode.Equals("FD"))
             {
                 Console.WriteLine(markerStringToSingleDigitDecimal(markerStringHexCode, 1).ToString());
                 return new JPG_N();
             }


             else if (markerStringHexCode.Equals("FE"))
             {
                 return new COM();
             }

             else if (markerStringHexCode.Equals("00") || markerStringHexCode.Equals("FF"))
             {
                 System.Console.WriteLine("Non marker code hex code submitted to MarkerFactory()");
                 return null;
             }

             else
             {
                 return new RES();
             }

             
        }

        public virtual String getId()
        {
            return this.GetType().ToString();
        }
        
        private int markerStringToSingleDigitDecimal(String hexcode, int digitPlace)
        {
            return System.Int32.Parse(hexcode.ElementAt(digitPlace).ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);

        }
    }
}
