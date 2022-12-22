namespace EventSystemTask;

public class Enemy
{
    public Enemy()
    {
        EventSystem.Subscribe("AttackWaveStart", AttackWaveStart);
        EventSystem.Subscribe("AttackWaveEnd", AttackWaveEnd);
        EventSystem.Subscribe<DateTime>("DateTime", DateTime);
    }

    private void AttackWaveStart()
    {
        Console.WriteLine($"[Враг] Сейчас {System.DateTime.Now:dd.MM.yyyy hh:mm:ss}, пошел бить игрока!");
    }

    private void AttackWaveEnd()
    {
        Console.WriteLine("[Враг] Я получил по лицу и возвращаюсь на базу");
    }

    private void DateTime(DateTime dateTime)
    {
        Console.WriteLine($"[Враг] Это все еще текущее время: {dateTime:hh:mm:ss}");
    }

}