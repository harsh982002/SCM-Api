using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Helpers.Enum;

namespace Common.Helpers
{
    public class Helper
    {
        public static DateTime GetCurrentUTCDateTime() => DateTime.UtcNow;

        /// <summary>
        /// The function returns the date difference.
        /// </summary>
        /// <param name="toDate">toDate</param>
        /// <param name="TimeUomId">TimeUomId</param>
        /// <returns>Returns the date difference.</returns>
        public static double DateDifferenceConversion(DateTime? toDate, byte TimeUomId)
        {
            if (toDate != null)
            {
                TimeSpan? date = DateTime.UtcNow - toDate;

                if (date.HasValue)
                {
                    if (TimeUomId == (byte)EnumTimeUom.Minutes)
                    {
                        return date.Value.TotalMinutes;
                    }
                    else if (TimeUomId == (byte)EnumTimeUom.Hours)
                    {
                        return date.Value.TotalHours;
                    }
                    else if (TimeUomId == (byte)EnumTimeUom.Days)
                    {
                        return date.Value.TotalDays;
                    }
                }
            }
            return 0;

        }

        /// <summary>
        /// The function returns converted time.
        /// </summary>
        /// <param name="time">time</param>
        /// <param name="fromTimeUomId">fromTimeUomId</param>
        /// <param name="toTimeUomId">toTimeUomId</param>
        /// <returns>Returns the converted time.</returns>

        public static short ConvertFromtoToTimeUom(short time, byte fromTimeUomId, byte toTimeUomId)
        {
            if (fromTimeUomId == toTimeUomId)
            {
                return time;
            }
            else if (fromTimeUomId == (byte)EnumTimeUom.Hours && toTimeUomId == (byte)EnumTimeUom.Minutes)
            {
                return (short)(time * 60);
            }
            else if (fromTimeUomId == (byte)EnumTimeUom.Days && toTimeUomId == (byte)EnumTimeUom.Hours)
            {
                return (short)(time * 24);
            }
            else if (fromTimeUomId == (byte)EnumTimeUom.Days && toTimeUomId == (byte)EnumTimeUom.Minutes)
            {
                return (short)(time * 24 * 60);
            }

            return 0;
        }

        /// <summary>
        /// Convert UTCDateTime To South Africa Standard Time.
        /// </summary>
        /// <param name="date">The UTC date.</param>
        /// <param name="timeZone">The timeZone.</param>
        /// <returns>DateTime.</returns>
        public static DateTime? ConvertUTCToSouthAfricaTimeZone(DateTime? date)
        {
            if (!date.HasValue)
                return date;

            TimeZoneInfo currentTimeZone;
            try
            {
                currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time");
            }
            catch (Exception)
            {
                return date;
            }

            return TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(date), currentTimeZone);
        }
    }
}
