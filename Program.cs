using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Program
    {

        static int CountTotal(List<string> total)
        {
            int cardTotal = 0;
            int iterator = 0;

            while (total.Count > iterator)
            {
                if (total[iterator] == "2 of Hearts" || total[iterator] == "2 of Spades" || total[iterator] == "2 of Diamonds" || total[iterator] == "2 of Clubs")
                {
                    cardTotal = cardTotal + 2;
                }
                if (total[iterator] == "3 of Hearts" || total[iterator] == "3 of Spades" || total[iterator] == "3 of Diamonds" || total[iterator] == "3 of Clubs")
                {
                    cardTotal = cardTotal + 3;
                }
                if (total[iterator] == "4 of Hearts" || total[iterator] == "4 of Spades" || total[iterator] == "4 of Diamonds" || total[iterator] == "4 of Clubs")
                {
                    cardTotal = cardTotal + 4;
                }
                if (total[iterator] == "5 of Hearts" || total[iterator] == "5 of Spades" || total[iterator] == "5 of Diamonds" || total[iterator] == "5 of Clubs")
                {
                    cardTotal = cardTotal + 5;
                }
                if (total[iterator] == "6 of Hearts" || total[iterator] == "6 of Spades" || total[iterator] == "6 of Diamonds" || total[iterator] == "6 of Clubs")
                {
                    cardTotal = cardTotal + 6;
                }
                if (total[iterator] == "7 of Hearts" || total[iterator] == "7 of Spades" || total[iterator] == "7 of Diamonds" || total[iterator] == "7 of Clubs")
                {
                    cardTotal = cardTotal + 7;
                }
                if (total[iterator] == "8 of Hearts" || total[iterator] == "8 of Spades" || total[iterator] == "8 of Diamonds" || total[iterator] == "8 of Clubs")
                {
                    cardTotal = cardTotal + 8;
                }
                if (total[iterator] == "9 of Hearts" || total[iterator] == "9 of Spades" || total[iterator] == "9 of Diamonds" || total[iterator] == "9 of Clubs")
                {
                    cardTotal = cardTotal + 9;
                }
                if (total[iterator] == "10 of Hearts" || total[iterator] == "10 of Spades" || total[iterator] == "10 of Diamonds" || total[iterator] == "10 of Clubs")
                {
                    cardTotal = cardTotal + 10;
                }
                if (total[iterator] == "Jack of Hearts" || total[iterator] == "Jack of Spades" || total[iterator] == "Jack of Diamonds" || total[iterator] == "Jack of Clubs")
                {
                    cardTotal = cardTotal + 10;
                }
                if (total[iterator] == "Queen of Hearts" || total[iterator] == "Queen of Spades" || total[iterator] == "Queen of Diamonds" || total[iterator] == "Queen of Clubs")
                {
                    cardTotal = cardTotal + 10;
                }
                if (total[iterator] == "King of Hearts" || total[iterator] == "King of Spades" || total[iterator] == "King of Diamonds" || total[iterator] == "King of Clubs")
                {
                    cardTotal = cardTotal + 10;
                }
                if (total[iterator] == "Ace of Hearts" || total[iterator] == "Ace of Spades" || total[iterator] == "Ace of Diamonds" || total[iterator] == "Ace of Clubs")
                {
                    cardTotal = cardTotal + 11;
                }
                iterator++;
            }

            return cardTotal;
        }

        static void PrintPlayersHand(List<string> hand)
        {
            Console.WriteLine("The cards in your hand are... ");
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i]);
            }
        }
        static void PrintDealersHand(List<string> hand)
        {
            Console.WriteLine("The Dealer's cards are... ");
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i]);
            }
        }

        static void PlayerWins()
        {
            Console.WriteLine();
            Console.WriteLine("Yay, you won!");
            Console.WriteLine();
        }

        static void DealerWins()
        {
            Console.WriteLine();
            Console.WriteLine("Bad luck! The Dealer won this round. ");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            string playAgain = "YES";

            while (playAgain == "YES")
            {
                //creating the deck
                var suits = new List<string>() { "Hearts", "Diamonds", "Clubs", "Spades" };
                var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
                var deck = new List<string>() { };

                foreach (var suit in suits)
                {
                    foreach (var face in faces)
                    {
                        var card = $"{face} of {suit}";
                        deck.Add(card);
                    }
                }

                //shuffle the cards using youtube method
                var decreasingIndex = deck.Count - 1; //sets the var as the last element
                                                      //creates a random number and then subtracts 1 as the index number goes from 0 to length-1

                while (decreasingIndex >= 0)
                {
                    Random r = new Random();
                    var randomIndex = r.Next(0, deck.Count);

                    var placeHolder1 = deck[decreasingIndex];
                    var placeHolder2 = deck[randomIndex];

                    deck[decreasingIndex] = placeHolder2;
                    deck[randomIndex] = placeHolder1;

                    //if we aren't at the first card, then look at the next one down the line and continue the shuffle
                    decreasingIndex = decreasingIndex - 1;


                }

                //int counter = 0;
                //while (counter < 52)
                //{
                //    Console.WriteLine(deck[counter]);
                //    counter++;
                //}

                //populate the strings for player and dealer's hands
                int cardsDealt = 0;
                var dealersHand = new List<string>() { deck[cardsDealt] };
                cardsDealt++;
                dealersHand.Add(deck[cardsDealt]);
                cardsDealt++;
                var playersHand = new List<string>() { deck[cardsDealt] };
                cardsDealt++;
                playersHand.Add(deck[cardsDealt]);
                cardsDealt++;

                //calculate the totals
                int dealersTotal = CountTotal(dealersHand);
                int playersTotal = CountTotal(playersHand);
                //Console.WriteLine($"the dealer's total is {dealersTotal}");
                //Console.WriteLine($"the player's total is {playersTotal}");

                PrintPlayersHand(playersHand);
                //PrintDealersHand(dealersHand);



                while (playersTotal < 21)
                {
                    Console.Write($"Would you like to HIT or STAND? ");
                    string decision = "";
                    decision = Console.ReadLine();

                    if (decision == "HIT")
                    {
                        playersHand.Add(deck[cardsDealt]);
                        cardsDealt++;
                        playersTotal = CountTotal(playersHand);
                        PrintPlayersHand(playersHand);
                        //Console.WriteLine($"the player's total is {playersTotal}");
                    }
                    else if (decision == "STAND")
                    {
                        Console.WriteLine("You have chosen to stick with your cards. Now the dealer will take a turn.");
                        PrintDealersHand(dealersHand);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter either HIT or STAND");
                    }
                }

                while (dealersTotal < 17)
                {
                    Console.WriteLine("The Dealer has chosen to HIT");
                    dealersHand.Add(deck[cardsDealt]);
                    cardsDealt++;
                    dealersTotal = CountTotal(dealersHand);
                    PrintDealersHand(dealersHand);
                    Console.WriteLine($"the dealer's total is {dealersTotal}");
                }

                if (dealersTotal == 17)
                {
                    //PrintDealersHand(dealersHand);
                    Console.WriteLine("The dealer has chosen to STAND");
                    if (dealersTotal >= playersTotal)
                    {
                        Console.WriteLine($"the dealer's total is {dealersTotal}");
                        Console.WriteLine($"the player's total is {playersTotal}");
                        DealerWins();
                    }
                    else
                    {
                        Console.WriteLine($"the dealer's total is {dealersTotal}");
                        Console.WriteLine($"the player's total is {playersTotal}");
                        PlayerWins();
                    }
                }

                if (dealersTotal > 17 && dealersTotal <= 21)
                {
                    //PrintDealersHand(dealersHand);
                    Console.WriteLine("The dealer has chosen to STAND");
                    if (dealersTotal >= playersTotal)
                    {
                        Console.WriteLine($"the dealer's total is {dealersTotal}");
                        Console.WriteLine($"the player's total is {playersTotal}");
                        DealerWins();
                    }
                }

                if (dealersTotal > 21)
                {
                    //PrintDealersHand(dealersHand);
                    //Console.WriteLine($"the dealer's total is {dealersTotal}");
                    //Console.WriteLine($"the player's total is {playersTotal}");
                    Console.WriteLine("The dealer has gone bust! ");
                    PlayerWins();
                }


                if (playersTotal == 21 && dealersTotal != 21)
                {
                    Console.WriteLine($"the dealer's total is {dealersTotal}");
                    Console.WriteLine($"the player's total is {playersTotal}");
                    PlayerWins();
                }

                Console.WriteLine("Would you like to play again? Choose YES or NO ");
                playAgain = Console.ReadLine();
            }


        }
    }
}
