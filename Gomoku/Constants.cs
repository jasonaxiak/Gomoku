namespace Gomoku;

public class Constants
{
    public static int BoardWidth(IConfiguration configuration)
    {
        return int.TryParse(configuration.GetSection("Game:BoardWidth").Value, out var value) ? value : 15;
    }

    public static int BoardLength(IConfiguration configuration)
    {
        return int.TryParse(configuration.GetSection("Game:BoardLength").Value, out var value) ? value : 15;
    }

    public static int ChainLengthToWin(IConfiguration configuration)
    {
        return int.TryParse(configuration.GetSection("Game:ChainLengthToWin").Value, out var value) ? value : 5;
    }
}