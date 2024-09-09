﻿int squareCount = 3;
int winningStreak = 3;
int[,] board = new int[squareCount, squareCount];
string[] key = ["[ ]", "[X]", "[O]"];
bool gameOver = false;
int gameCounter = 0;

void PrintBoard()
{
    for (int i = 0; i < squareCount; i++)
    {
        Console.Write("|");

        for (int j = 0; j < squareCount; j++)
        {
            Console.Write($" {key[board[i, j]]}");
        }
        Console.WriteLine(" |");
    }
}

while (!gameOver)
{
    Console.Clear();
    PrintBoard();
    
    Console.WriteLine("Write row and column separated by a comma (example: 1,2)");
    string[] coordinates = Console.ReadLine().Split(",");
    
    int row = int.Parse(coordinates[0]) - 1;
    int column = int.Parse(coordinates[1]) - 1;

    bool isInvalidSpace = true;
    while (isInvalidSpace)
    {
        isInvalidSpace = CheckOutOfBounds(row, column);
        if (!isInvalidSpace)
        {
            isInvalidSpace = board[row, column] != 0;
            if (!isInvalidSpace) break;
        }
        Console.WriteLine("That space is invalid. Pick a different space please: ");
        coordinates = Console.ReadLine().Split(",");
        row = int.Parse(coordinates[0]) - 1;
        column = int.Parse(coordinates[1]) - 1;
    }
    
    board[row, column] = gameCounter % 2 + 1;

    CheckWinner();
    gameCounter++;
}

void CheckWinner()
{
    int streak;
    for (int i = 0; i < squareCount; i++)
    {
        streak = 0;
        for (int j = 1; j < squareCount; j++)
        {
            if (board[i, j - 1] == board[i, j] && board[i, j] != 0) streak++;
            else streak = 0;
        }
        if (streak == winningStreak - 1) gameOver = true;

        streak = 0;
        for (int j = 1; j < squareCount; j++)
        {
            if (board[j - 1, i] == board[j, i] && board[j, i] != 0) streak++;
            else streak = 0;
        }
        if (streak == winningStreak - 1) gameOver = true;
    }
    
    if (gameOver)
    {
        Console.Clear();
        PrintBoard();
        Console.WriteLine("Congratulations you win!");
    }
        
}

/*void CheckWinner()
{
    for (int i = 0; i < squareCount; i++)
    {
        if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != 0)
        {
            gameOver = true;
        }  
        else if (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] != 0)
        {
            gameOver = true;
        }
    }

    if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[1, 1] != 0)
    {
        gameOver = true;
    }
    else if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[1, 1] != 0)
    {
        gameOver = true;
    }

    if (gameOver)
    {
        Console.Clear();
        PrintBoard();
        Console.WriteLine("Congratulations you win!");
    }
}*/

bool CheckOutOfBounds(int row , int column)
{
    return row > squareCount || row < 0 || column > squareCount || column < 0;
}