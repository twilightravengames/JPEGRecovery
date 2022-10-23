using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JPEG_Recover.Headers;

namespace JPEG_Recover.Segments
{
    public class Frame : Segment
    {
        TableOrMiscObject_Optional tableOrMiscSegment;
        FrameHeader frameHeader;
        List<Scan> scanSegmentsList;
        List<DNLSegment> DNLSegmentsList;
    }
}
