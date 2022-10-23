using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JPEG_Recover.Headers;
using JPEG_Recover.Markers;

namespace JPEG_Recover.Segments
{
    public class Scan : Segment
    {
        TableOrMiscObject_Optional tableOrMiscSegment;
        ScanHeader scanHeader;
        List<EntropyCodedSegment> entropyCodedSegmentList;
        List<RST_M> restMarkersList;
    }
}
