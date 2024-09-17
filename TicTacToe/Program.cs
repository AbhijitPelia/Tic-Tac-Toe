using System;

class TicTacToe
{

    //The game board represented as an array which is initially represented by numbers 1-9
    static string [] gameGrid = new string [9] {"1","2","3","4","5","6","7","8","9"};  

    //The variable game controls the game loop, which runs while game is true
    static bool game = true;

    static void Main(string[] args)
    {
        Console.Clear(); 
        GameBoard(); //Calls the method GameBoard which displays the inital game board
        PlayerMove(); //Calls the method PlayerMove which handles the players moves
    }

    //Method to display the game board
    static void GameBoard()
    {
        string gameName = "Tic Tac Toe!!"; //Title of the game
        int displayWidth = 25; //Width of the display area

        //Centers the game in name in the display area
        if (!string.IsNullOrEmpty(gameName) && displayWidth > gameName.Length)
        {
            int padding = (displayWidth - gameName.Length) / 2;
            gameName = gameName.PadLeft(gameName.Length + padding).PadRight(displayWidth);
        }

        //Display the game name 
        Console.WriteLine(gameName);
        Console.WriteLine();

        //Displayes the 3x3 game grid which is initiallly numbers 1-9
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(gameGrid[i * 3 + j] + " | "); //Display each cell with a separator
            }
            Console.WriteLine();
            Console.WriteLine("-----------"); //Row separator
        }
    }

    //Method to handle player moves
    static void PlayerMove()
    {
        bool player1Turn = true; //Tracks whose turn it is
        int turns = 0; //Counts the number of turns - max 9

        //While loop to control how long the game continues for
        while(game)
        {
            Console.WriteLine();

            //To indicate whos turn it is
            if(player1Turn)
                Console.WriteLine("Player X make a move!");
            else  
                Console.WriteLine("Player O make a move");

            //Reads player input for their move
            string playerChoice = Console.ReadLine();       
            int.TryParse(playerChoice, out int choice);
        
            //Check if the chosen move is a valid valid number from 1-9
            if(choice >= 1 && choice <= 9)
            {
                int gameGridIndex = choice - 1; //Converts player choice to 0-based index

                //Checks if the chosen move is not already occupied 
                if(gameGrid.Contains(playerChoice) && playerChoice != "X" && playerChoice != "0")
                {
                    //If its player 1's turn converts the index of gameGrid to "X" otherwise changes it to "O"
                    if (player1Turn)
                        {
                            gameGrid[gameGridIndex] = "X";
                            GameBoard();
                        }
                    else
                        {
                            gameGrid[gameGridIndex] = "O";
                            GameBoard();
                        }

                    turns++; //Increases the turns count by 1
                }
                else
                {
                    //Displays message if the cell is already occupied 
                    Console.WriteLine("Sqaure already taken, please chose another square!");
                    GameBoard(); //Calls the GameBoard method to display the game board again
                    player1Turn = !player1Turn; //Reverts the turn so the same player goes again
                }
            
            GameResult(); //Calls the GameResult Method to see if there is a winner

                //If the turns counter reaches to 9 and game is true, declares a tie
                if(turns == 9 && game)
                {
                    Console.WriteLine("Game Over, TIE!!");
                    game = !game; //Ends the game
                }

                player1Turn = !player1Turn; //Switches turns between players
            
            }
            else
            {
                //Notifies player that they made an invalid selection
                Console.WriteLine("Inavlid selection, please chose an avaiable square!");
                GameBoard(); //Re-display the game board
            }
        }
    }

    //Method to check if there is a winner
    static void GameResult()
    {
        //Checks all possible winning combinations (rows, columns, diagonals) by calling the CheckWinner method
        if(
        CheckWinner(gameGrid[0], gameGrid[1], gameGrid[2]) ||
        CheckWinner(gameGrid[3], gameGrid[4], gameGrid[5]) ||
        CheckWinner(gameGrid[6], gameGrid[7], gameGrid[8]) ||
        CheckWinner(gameGrid[0], gameGrid[3], gameGrid[6]) ||
        CheckWinner(gameGrid[1], gameGrid[4], gameGrid[7]) ||
        CheckWinner(gameGrid[2], gameGrid[5], gameGrid[8]) ||
        CheckWinner(gameGrid[0], gameGrid[4], gameGrid[8]) ||
        CheckWinner(gameGrid[2], gameGrid[4], gameGrid[6]) )
        {
            game = false; //End the game if there is a winner
        }
    }

    //Method to determine who won
    static bool CheckWinner(string a, string b, string c)
    {
        //Check if all three cells are the same, meaning a player has won
        if(a == b && b == c)
        {
            if (a == "X")
            {
                Console.WriteLine("Game Over, PLAYER X WON!!"); //Announce player X has won
                game = false; //End the game
            }
            else
            {
                Console.WriteLine("Game Over, PLAYER O WON!!"); //Announce player O has won
                game = false; //End the game
            }
            return true; //Return true if there's a winner
        }
        return false; //Return flase if there's no winner
    }
}