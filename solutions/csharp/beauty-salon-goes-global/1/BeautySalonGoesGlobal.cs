using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        dtUtc = DateTime.SpecifyKind(dtUtc, DateTimeKind.Utc);
        return dtUtc.ToLocalTime(); 
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime localTime = DateTime.Parse(appointmentDateDescription);
    
        string timeZoneId;
    
        if (OperatingSystem.IsWindows()){
            timeZoneId = location switch{
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W. Europe Standard Time",
                _ => throw new ArgumentException()
            };
        }else{
            timeZoneId = location switch{
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
                _ => throw new ArgumentException()
            };
        }
    
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    
        return TimeZoneInfo.ConvertTimeToUtc(localTime, tz);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch(alertLevel){
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddHours(-1).AddMinutes(-45);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);

            default:
                return appointment;
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        
        string timeZoneId;

        if (OperatingSystem.IsWindows()){
            timeZoneId = location switch{
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W. Europe Standard Time",
                _ => throw new ArgumentException()
            };
        }else{
            timeZoneId = location switch{
                Location.NewYork => "America/New_York",
                Location.London => "Europe/London",
                Location.Paris => "Europe/Paris",
                _ => throw new ArgumentException()
            };
        }

        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        if(tz.SupportsDaylightSavingTime){
            return tz.IsDaylightSavingTime(dt) != tz.IsDaylightSavingTime(dt.AddDays(-7));
        }
        return false;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string format = location switch{
            Location.NewYork => "MM/dd/yyyy HH:mm:ss",
            Location.London => "dd/MM/yyyy HH:mm:ss",
            Location.Paris => "dd/MM/yyyy HH:mm:ss",
            _ => throw new ArgumentException()
        };
    
        if (DateTime.TryParseExact(dtStr, format, CultureInfo.InvariantCulture, 
            DateTimeStyles.None, out DateTime result)){
            return result;
        }
    
        return DateTime.MinValue;
    }
}
