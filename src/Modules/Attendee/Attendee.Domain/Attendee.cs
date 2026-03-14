namespace Attendee.Domain;

public class AttendeeEntity
{
    public int ID { get; set; }
    public string AccountName { get; set; } = "";
    public bool IsAttended { get; set; }

    public void ToggleAttendance()
    {
        IsAttended = !IsAttended;
    }
}
