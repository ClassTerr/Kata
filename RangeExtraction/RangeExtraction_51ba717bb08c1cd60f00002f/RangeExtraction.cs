using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RangeExtraction_51ba717bb08c1cd60f00002f;

public class RangeExtraction
{
    public static string Extract(int[] args)
    {
        var result = new List<string>();
        int startRange = args[0], endRange = args[0];
        foreach (var num in args.Skip(1).Append(args[^1] + 2))
        {
            if (Math.Abs(endRange - num) == 1)
            {
                // If the range contains only one element or the number follows the order just add number to the range and continue.
                if (startRange == endRange || Math.Sign(startRange - endRange) == Math.Sign(endRange - num))
                {
                    endRange = num;
                    continue;
                }
            }

            // Here current range breaks
            if (Math.Abs(startRange - endRange) > 1)
            {
                result.Add(startRange + "-" + endRange);
            }
            else
            {
                result.Add(startRange.ToString());

                if (startRange != endRange)
                {
                    result.Add(endRange.ToString());
                }
            }

            startRange = endRange = num;
        }

        return string.Join(",", result);
    }
}
