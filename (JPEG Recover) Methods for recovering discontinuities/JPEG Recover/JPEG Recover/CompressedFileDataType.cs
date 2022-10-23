using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JPEG_Recover
{
    //Top level Data Type
    public abstract class CompressedFileDataType
    {
        
        int startOffset = -1;
        int endOffset = -1;
        int sizeOfChunk = -1;
        Boolean isValidated = false;

        //public abstract Boolean validate();

        //public abstract int writeToFile(File file);

        public void setStartOffset(int startOffset)
        {
            this.startOffset = startOffset;
        }

        public int getStartOffset()
        {
            return startOffset;
        }

        public void setEndOffset(int endOffset)
        {
            this.endOffset = endOffset;
        }

        public int getEndOffset()
        {
            return endOffset;
        }
        
    }
}
