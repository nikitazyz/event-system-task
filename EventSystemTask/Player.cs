// ReSharper disable StringLiteralTypo
namespace EventSystemTask;

public class Player
{
    public Player()
    {
        EventSystem.Subscribe("AttackWaveStart", AttackWaveStart);
        EventSystem.Subscribe("AttackWaveEnd", AttackWaveEnd);
        EventSystem.Subscribe<DateTime>("DateTime", DateTime);
    }

    private void AttackWaveStart()
    {
        Console.WriteLine($"[Игрок] Сейчас {System.DateTime.Now:dd.MM.yyyy hh:mm:ss}, я готов к отражению атаки монстров!");
    }

    private void AttackWaveEnd()
    {
        Console.WriteLine("[Игрок] Я успешно отбился от врагов и теперь могу вернуться домой");
    }

    private void DateTime(DateTime dateTime)
    {
        Console.WriteLine($"[Игрок] Текущее время: {dateTime:hh:mm:ss}");
    }
}