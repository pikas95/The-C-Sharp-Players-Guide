TerrainType[,] array = new TerrainType[4, 8];
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 8; j++)
    {
        string input = Console.ReadLine();
        if (input == Convert.ToString(TerrainType.w))
            array[i, j] = TerrainType.w;
        else if (input == Convert.ToString(TerrainType.l))
            array[i, j] = TerrainType.l ;
        else if (input == Convert.ToString(TerrainType.m))
            array[i, j] = TerrainType.m ;
        else
            array[i, j] = TerrainType.c ;
    }
}
DisplayMap(array);
void DisplayMap(TerrainType[,] array)
{
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (array[i, j] == TerrainType.w)
                Console.Write("~~");
            else if (array[i, j] == TerrainType.c)
                Console.Write("()");
            else if (array[i, j] == TerrainType.m)
                Console.Write("^^");
            else
                Console.Write("  ");
        }
        Console.WriteLine();
    }
}

enum TerrainType { w, l, m, c }