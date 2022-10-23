using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JPEG_Recover.Segments;
using System.IO;
using JPEG_Recover.Markers;

namespace JPEG_Recover
{
    public class JPEGFile : CompressedFileDataType
    {
        JPEG_Recover.Markers.SOI soi; //start of iamge marker
        JPEG_Recover.Markers.EOI eoi; //end of image marker
        Frame frame;
        String filename;

        FileStream stream;
            
        BinaryReader reader;

        //!needs to be revised for write mode
        public int openJPG(String filename) //open a File object using filename passed. JPEG filetypes only
        {
            stream = new FileStream(filename, FileMode.Open);
            
            reader = new BinaryReader(stream);

            this.filename = filename;
            
            return -1; //fail
        }

        //!deprecated
        public int readAndOutputMarkerData() //only read the markers into the data structure heirarchy
        {
            byte [] bytepair = new byte[2];
            int byteCtr = 0;

            while (true)
            {

                try
                {
                    //--read bytes--//
                    bytepair[0] = reader.ReadByte();
                    bytepair[1] = reader.ReadByte();

                    byteCtr += 2;

                    //--setup marker comparisons--//

                    byte initialMarkerByte = Convert.ToByte(System.Int32.Parse("FF", System.Globalization.NumberStyles.AllowHexSpecifier));

                    //--compare bytes--//


                    if (bytepair[0] == initialMarkerByte)
                    {
                        //second byte comparison
                        Marker marker;
                        if ((marker = secondByteMarkerCompare(bytepair[1])) != null)
                        {
                            Console.WriteLine("Byte Counter for (above) second byte is: " + byteCtr);
                            readMarkerBytes(marker);
                        }
                    }
                    else if (bytepair[1] == initialMarkerByte)
                    {
                        //read next byte to see if it is part of a marker
                        bytepair[0] = bytepair[1];
                        bytepair[1] = reader.ReadByte();
                        byteCtr++;

                        Marker marker;
                        if ((marker = secondByteMarkerCompare(bytepair[1])) != null)
                        {
                            Console.WriteLine("Byte Counter for (above) second byte is: " + byteCtr);
                            readMarkerBytes(marker);
                        }
                        //second byte comparison
                    }
                    

                }
                catch (EndOfStreamException)
                {
                    System.Console.WriteLine("Reached End of Stream at byte number:" + byteCtr);
                    System.Console.WriteLine("Press enter to continue..");
                    System.Console.ReadLine();
                    break;
                }
               
            }

            return -1;
            
        }

        
        //on success returns marker, on fail returns null
        private Marker secondByteMarkerCompare(byte comparisonByte)
        {

            byte ZeroByte = Convert.ToByte(System.Int32.Parse("00", System.Globalization.NumberStyles.AllowHexSpecifier));
            byte SixteenByte = Convert.ToByte(System.Int32.Parse("FF", System.Globalization.NumberStyles.AllowHexSpecifier));
            try
            {
                if (comparisonByte != ZeroByte && comparisonByte != SixteenByte)
                {
                    Console.WriteLine("Current Byte is part of a Marker Byte. Second Byte is (in hex): " + comparisonByte.ToString("X"));
                    Marker markerFactory = new Marker();

                    Marker marker = markerFactory.getMarker(comparisonByte);
                    

                    if (marker != null && !(marker is RES))
                    {
                        System.Console.WriteLine(marker.getId());
                        return marker;
                    }
                    
                }
                return null; 
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null Reference Exception");
                return null;
            }
            

            
        }

        //! deprecated
        //reads subsequent bytes following marker
        //returns -1 on failure, 1 on success
        public int readMarkerBytes(Marker marker)
        {
            //marker.readHeader();
            //marker.readBytes();
            return -1;
        }

        
        public int readAndStoreData()  //read and store all data into the data structure heirarchy(
        {
            return -1; //fail
        }


        public int close()
        {
            reader.Close();
            return -1; //failed
        }

        //! deprecated
        public int readwrite()
        {
            FileStream ostream = new FileStream("C:\\Users\\Ted\\Desktop\\bunch\\IMG_002RECOVERED.JPG", FileMode.CreateNew);
           
            BinaryWriter writer = new BinaryWriter(ostream);
            
            byte [] SOIByte = new byte[2];

            SOIByte[0] = Convert.ToByte(System.Int32.Parse("FF", System.Globalization.NumberStyles.AllowHexSpecifier));
            SOIByte[1] = Convert.ToByte(System.Int32.Parse("D8", System.Globalization.NumberStyles.AllowHexSpecifier));

            writer.Write(SOIByte[0]);
            writer.Write(SOIByte[1]);

            byte [] bufferedBytes = new byte[100];

            try {

                bufferedBytes = reader.ReadBytes(100);

                for (int i=0;i<100;i++)
                {
                    writer.Write(bufferedBytes[i]);
                }

            }
            catch(Exception)
            {
                Console.WriteLine("Caught an exception");
            }

            return -1;
        }
    }
}
