class Program
    {
        const int CMaxSize = 100;
        const string CFd1 = "RentalPoint1.txt";
        const string CFd2 = "RentalPoint2.txt";
        const string CResults = "Results.txt";

        static void Read(string fv, Bicycle[] B, out int n, out string rentalPoint)
        {
            string bikeModel;
            int numOfBikes;
            int year;
            double price;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                rentalPoint = line;
                string[] parts;
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    bikeModel = parts[0];
                    numOfBikes = int.Parse(parts[1]);
                    year = int.Parse(parts[2]);
                    price = double.Parse(parts[3]);
                    B[i] = new Bicycle(bikeModel, numOfBikes, year, price);
                }
            }
        }

        static void Print(string header, string rentalPoint, Bicycle[] B, int n)
        {
            Console.Write(header);
            Console.WriteLine(rentalPoint);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|          Model |  Num |  Year |    Price |");
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("| {0,14} | {1,4:d} | {2,5:d} | {3, 8:f2} |",
                B[i].GetBikeModel(),
               B[i].GetNUmberOfBIkes(),
               B[i].GetYear(),
               B[i].GetPrice());
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
        }

        static void PrintToTextFile(string file, string header, string rentalPoint, Bicycle[] B, int n)
        {
            using (StreamWriter writer = new StreamWriter(file, true)) 
            {
                writer.Write(header);
                writer.WriteLine(rentalPoint);
                writer.WriteLine("--------------------------------------------");
                writer.WriteLine("|          Model |  Num |  Year |    Price |");
                writer.WriteLine("--------------------------------------------");
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine("| {0,14} | {1,4:d} | {2,5:d} | {3, 8:f2} |",
                    B[i].GetBikeModel(),
                   B[i].GetNUmberOfBIkes(),
                   B[i].GetYear(),
                   B[i].GetPrice());
                }
                writer.WriteLine("--------------------------------------------");
                writer.WriteLine();
            }
        }

        static Bicycle MostExpensiveInOneCollection(Bicycle[] B, int n)
        {
            Bicycle mostExpensive = B[0];
            for (int i = 0; i < n; i++)
            {
                if (B[i].GetPrice() > mostExpensive.GetPrice())
                {
                    mostExpensive = B[i];
                }
            }
            return mostExpensive;
        }

        static void MostExpensives(Bicycle[] B, Bicycle[] B1, Bicycle[] B3, int n1, int n2, out int numberOfElements)
        {
            numberOfElements = 0;
            string bikeModel;
            int numOfBikes;
            int year;
            double price;

            if (MostExpensiveInOneCollection(B, n1).GetPrice() >= MostExpensiveInOneCollection(B1, n2).GetPrice())
            {
                for (int i = 0; i < n1; i++)
                {
                    if (B[i].GetPrice() == MostExpensiveInOneCollection(B, n1).GetPrice())
                    {
                        bikeModel = B[i].GetBikeModel();
                        numOfBikes = B[i].GetNUmberOfBIkes();
                        year = B[i].GetYear();
                        price = B[i].GetPrice();
                        B3[numberOfElements] = new Bicycle(bikeModel, numOfBikes, year, price);
                        numberOfElements++;
                    }
                }
                for (int i = 0; i < n2; i++)
                {
                    if (B1[i].GetPrice() == MostExpensiveInOneCollection(B, n1).GetPrice())
                    {
                        bikeModel = B1[i].GetBikeModel();
                        numOfBikes = B1[i].GetNUmberOfBIkes();
                        year = B1[i].GetYear();
                        price = B1[i].GetPrice();
                        B3[numberOfElements] = new Bicycle(bikeModel, numOfBikes, year, price);
                        numberOfElements++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n1; i++)
                {
                    if (B[i].GetPrice() == MostExpensiveInOneCollection(B1, n2).GetPrice())
                    {
                        bikeModel = B[i].GetBikeModel();
                        numOfBikes = B[i].GetNUmberOfBIkes();
                        year = B[i].GetYear();
                        price = B[i].GetPrice();
                        B3[numberOfElements] = new Bicycle(bikeModel, numOfBikes, year, price);
                        numberOfElements++;
                    }
                }
                for (int i = 0; i < n2; i++)
                {
                    if (B1[i].GetPrice() == MostExpensiveInOneCollection(B1, n2).GetPrice())
                    {
                        bikeModel = B1[i].GetBikeModel();
                        numOfBikes = B1[i].GetNUmberOfBIkes();
                        year = B1[i].GetYear();
                        price = B1[i].GetPrice();
                        B3[numberOfElements] = new Bicycle(bikeModel, numOfBikes, year, price);
                        numberOfElements++;
                    }
                }
            }
            
        }

        static void Main(string[] args)
        {
            Bicycle[] B1 = new Bicycle[CMaxSize]; 
            int n1; 
            string rentalPoint1; 


            Bicycle[] B2 = new Bicycle[CMaxSize]; 
            int n2; 
            string rentalPoint2; 

            Read(CFd1, B1, out n1, out rentalPoint1);
            Read(CFd2, B2, out n2, out rentalPoint2);
   
            Print("Initial data: ", rentalPoint1, B1, n1);
            Print("Initial data: ", rentalPoint2, B2, n2);

            Bicycle[] B3 = new Bicycle[CMaxSize];
            int numberOfElements = 0;

            if (File.Exists(CResults))
            {
                File.Delete(CResults);
            }

            PrintToTextFile(CResults, "Initial data: ", rentalPoint1, B1, n1);
            PrintToTextFile(CResults, "Initial data: ", rentalPoint2, B2, n2);

            MostExpensives(B1, B2, B3, n1, n2, out numberOfElements);
            PrintToTextFile(CResults, "Most Expensives: ", "General", B3, numberOfElements);
        }
    }
