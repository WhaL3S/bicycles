class Bicycle
    {
        private string bikeModel;
        private int numberOfBikes;
        private int year;
        private double price;

        public Bicycle(string bikeModel, int numberOfBikes, int year, double price)
        {
            this.bikeModel = bikeModel;
            this.numberOfBikes = numberOfBikes;
            this.year = year;
            this.price = price;
        }

        public string GetBikeModel()  { return bikeModel;     }
        public int GetNUmberOfBIkes() { return numberOfBikes; }
        public int GetYear()          { return year;          }
        public double GetPrice()      { return price;         }

        public void SetBikeModel(string bikeModel)      { this.bikeModel = bikeModel;         }
        public void SetNumberOfBikes(int numberOfBikes) { this.numberOfBikes = numberOfBikes; }

        
    }
