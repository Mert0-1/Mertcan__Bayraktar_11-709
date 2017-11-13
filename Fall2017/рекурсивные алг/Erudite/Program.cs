using System;

namespace Erudite
{
    
    sealed class erudite
    {
        //There i used DFS
        static void Main()
        {
             int size = 4;
             char border = ' ';
            string[] table = new string[size + 2];
            table[0] = table[size + 1] = new String(border, size + 2);
            for (int i = 1; i <= size; i++) table[i] = border + Console.ReadLine() + border;
            for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
            {
                string word = Console.ReadLine();
                bool find = false;
                bool[,] mark = new bool[size + 2, size + 2];
                for (int x = 1; !find && x <= size; x++)
                    for (int y = 1; !find && y <= size; y++)
                    {
                        if (table[y][x] != word[0]) continue;
                        Array.Clear(mark, 0, mark.Length);
                        find = Search(word, table, mark, y, x, 1); // 
                    }
                Console.WriteLine(word + ": " + (find ? "YES" : "NO"));
            }
        }

        static readonly int[,] direction = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        static bool Search(string word, string[] table, bool[,] mark, int y, int x, int depth)
        {
            if (mark[y, x]) return false;
            mark[y, x] = true;
            if (depth == word.Length) return true;
            for (int i = 0; i < 4; i++)
            {
                int y1 = y + direction[i, 0];
                int x1 = x + direction[i, 1];
                if (table[y1][x1] == word[depth] && Search(word, table, mark, y1, x1, depth + 1)) return true;
            }
            return mark[y, x] = false;
        }
    }
}