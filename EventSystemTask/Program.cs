namespace EventSystemTask;

internal static class Program
{
    private static readonly string AttackWaveStartEvent = "AttackWaveStart";
    private static readonly string AttackWaveEndEvent = "AttackWaveEnd";
    private static readonly string DateTimeEvent = "DateTime";

    public static void Main(string[] args)
    {
        EventSystem.CreateEvent(AttackWaveStartEvent);
        EventSystem.CreateEvent(AttackWaveEndEvent);
        EventSystem.CreateEvent<DateTime>(DateTimeEvent);

        Player player = new Player();
        Enemy enemy = new Enemy();

        while (true)
        {
            EventSystem.RaiseEvent(AttackWaveStartEvent);
            EventSystem.RaiseEvent(AttackWaveEndEvent);
            Thread.Sleep(1000);
            EventSystem.RaiseEvent(DateTimeEvent, DateTime.Now);
        }
    }
}