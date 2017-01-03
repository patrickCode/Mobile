using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Java.Util;

namespace Chronos.Droid.NativeServices
{
    public class CalenderService
    {
        private Activity _currentContext;
        public CalenderService(Activity currentContext)
        {
            _currentContext = currentContext;
        }

        public long AddCalendarEvent(string eventTitle, string eventDescription, DateTime startDate, DateTime endDate, System.TimeZone eventTimezone, bool exactTime = true)
        {
            var eventValues = new ContentValues();
            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, 1);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title, eventTitle);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description, eventDescription);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart, GetTimeInMs(startDate, eventTimezone, exactTime));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetTimeInMs(endDate, eventTimezone, exactTime));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");
            var uri = _currentContext.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
            
            return 0;
        }

        private long GetTimeInMs(DateTime date, System.TimeZone timezone, bool withTime = true)
        {
            var year = date.Year;
            var month = date.Month - 1;
            var day = date.Day;
            var hour = date.Hour;
            var androidTimezone = Java.Util.TimeZone.Default;

            var calender = Calendar.GetInstance(androidTimezone);
            calender.Set(Java.Util.CalendarField.DayOfMonth, day);
            //calender.Set(CalendarField.HourOfDay, hour);
            calender.Set(CalendarField.Month, month);
            calender.Set(CalendarField.Year, year);

            return calender.TimeInMillis;
        }
    }
}