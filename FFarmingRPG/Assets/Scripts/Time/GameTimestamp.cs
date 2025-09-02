using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameTimestamp
{
    
    public int year;

    public enum Season
    {
        Spring, Summer, Fall, Winter // ilkbahar, yaz, sonbahar, kış
    }

    public Season season;


    // yabancıların takviminde pazar pazartesi diye gidiyor
    // fakat günü hesaplarken modu 0 olan günün 7. gün olması gerekiyor bu yüzden başa yazdık
    public enum DayOfTheWeek
    {
        Saturday, 
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
        
    }


    public int day;
    public int hour;
    public int minute;

    public GameTimestamp(int year, Season season, int day, int hour, int minute)
    {
        this.year = year;
        this.season = season;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
    }

    public void UpdateClock()
    {
        minute++;

        if (minute >= 60)
        {
            minute = 0;
            hour++;
        }

        if(hour >= 24)
        {
            hour = 0;
            day++;
        }

        // Seasonları normalde 90 günde bir arttırmak gerekiyordu fakat biz ay gibi 30 günde bir arttıracaz 
        if(day >= 30)
        {
            day = 1;

            if(season == Season.Winter)
            {
                season = Season.Spring;
                year++;
            }   
            else 
            {
                season++;
            }
        }


    }

    public DayOfTheWeek GetDayOfTheWeek()
    {
        int dayPassed =  YearsToDays(year) + SeasonToDays(season) + day;

        int dayIndex = dayPassed % 7;

        return (DayOfTheWeek)dayIndex;
    }


    public static int HoursToMinutes(int hour)
    {
        return hour * 60;
    }

    public static int DaysToHours(int days)
    {
        return days * 24;
    }

    public static int SeasonToDays(Season season)
    {
        int seasonIndex = (int)season;
        return seasonIndex * 30;
    }

    public static int YearsToDays(int years)
    {
        return years * 4 * 30;
    }


}
