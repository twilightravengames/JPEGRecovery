using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPEG_Recover
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < args.Length; i++)
            {
                JPEGBufferedStorage jpeg = new JPEGBufferedStorage();
                jpeg.openJPG(args[i]);

                //jpeg.readAndOutputMarkerData();
                //jpeg.readwrite();

                jpeg.close();
            }

            //open and write to hierarchical file

        }
            /*
             JPEGFile jpeg;

        for (int i=0;i<argument.size;i++)
        {
	        jpeg.openJPG(argument[0]);
	        jpeg.recordMarkers() (for final application will be a simple read of compressed file into data structure heirarchy)
	        jpeg.validateChunks()
	        jpeg.correctChunks()
	        jpeg.recreateChunks();
	        jpeg.writeToFile(argument[i]+"corrected")
        }
            */

        
    }
}


/*
//////////////////////////////////

Heirarchical JPEG  Format

All Data Types inherit from type "CompressedFileDatatype" which contains start_offset

class JPEG File
{

	SOI_Marker:Marker
	Frame Object:Segment
	EOI Marker:Marker
}

class Frame:Segment
{
	Table/Misc. Object:Optional Segment
	Frame Header:Header
	List<Scan Object:Segment>
	List<DNL Segment:Optional Segment>
	
}

class Scan:Segment
{
	Table/Misc.Object:Optional Segment
	Scan Header:Header
	List<Entropy Coded Object:Segment>
	List<Restart:Marker>
}

class Entropy Coded:Segment
{
	List<MCU>
}
*/

/*
Apoplication Possible Implementation Overview

1. Search for all markers and record their location and type (include JFIF markers such as APP0, etc..)
2. Take chunks of data following markers and validate them for each type, store in 
appropriate data structures 
(Possible data structure: include data types for storage of data and validation routines specific to marker)
3. Take validated chunks, correct invalid chunks and recreate missing chunks (such as SOI header) if necessary (and if possible)
4. Write chunks to file as reconstructed JPEG file 
5. End Algorithm

--recreating headers--

analyze data that is missing markers and try to look for patterns which would indicate the marker type

*/