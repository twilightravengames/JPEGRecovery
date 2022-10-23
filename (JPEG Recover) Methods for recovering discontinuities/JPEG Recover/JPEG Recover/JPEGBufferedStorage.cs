using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JPEG_Recover
{
    //an order preserving sequential data type to represent JPEG segments 
    class JPEGBufferedStorage : CompressedFileDataType
    {
        List<Byte> fileByteBufferedList = new List<Byte>(); // contains all file data in a byte buffer list
        //include metadata for locations of important data such as markers
        //meta data created while reading the file
        public void openJPG(String filename)
        {
        }

        public void close()
        {
        }
    }
}
