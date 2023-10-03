using System;
using System.Security.Cryptography.X509Certificates;

namespace lab3
{
    class task1{
        class Vector{
            public int x{
                get { return this.x;}
                set { this.x = value;}
            }
            public int y{
                get { return this.y;}
                set { this.y = value;}
            }

            public int z{
                get { return this.z;}
                set { this.z = value;}
            }
            public Vector(int x, int y, int z){
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Vector operator +(Vector vector1, Vector vector2){
                int x = vector1.x + vector2.x;
                int y = vector1.y + vector2.y;
                int z = vector1.z + vector2.z;
                return new Vector(x, y, z);
            }

            public static Vector operator *(Vector vector1, Vector vector2){
                int x = vector1.x * vector2.x;
                int y = vector1.y * vector2.y;
                int z = vector1.z * vector2.z;
                return new Vector(x, y, z);
            }

            public static Vector operator *(Vector vector, int lambda){
                return new Vector(vector.x * lambda, vector.y * lambda, vector.z * lambda);
            }

            public static bool operator >(Vector vector1, Vector vector2){
                return Math.Sqrt(vector1.x * vector1.x + vector1.y * vector1.y + vector1.z * vector1.z) > Math.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z);
            }

            public static bool operator <(Vector vector1, Vector vector2){
                return Math.Sqrt(vector1.x * vector1.x + vector1.y * vector1.y + vector1.z * vector1.z) < Math.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z);
            }
        }
    }

    class task2{
        class Car : IEquatable<Car>
        {
            string name;
            string engine;
            int maxSpeed;

            public override string ToString()
            {
                return name;
            }

            public bool Equals(Car other){
                if (other == null){
                    return false;
                }
                return name == other.name && engine == other.engine && maxSpeed == other.maxSpeed; 
            }

            public override bool Equals(object? obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                return Equals((Car)obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(name, engine, maxSpeed);
            }

        }

        class CarsCatalog{
            List <Car> cars = new List<Car>();

            public Car this[int index]
            {
                get
                {
                    if (index >= 0 && index <= cars.Count)
                    {
                        return cars[index];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index is out of range");
                    }
                }
                set
                {
                    if (index >= 0 && index <= cars.Count)
                    {
                        cars[index] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index is out of range");
                    }
                }
            }

            public void AddCar(Car car){
                cars.Add(car);
            }

            public void RemoveCar(Car car){
                cars.Remove(car);
            }
        }
    }

    class task3{
        class Currency
        {
            public double Value { get; set; }

            public Currency(double value)
            {
                Value = value;
            }
        }

        class CurrencyUSD : Currency
        {
            public CurrencyUSD(double value) : base(value) { }

            public static implicit operator CurrencyEUR(CurrencyUSD usd)
            {
                double exchangeRate = 0.99;
                return new CurrencyEUR(usd.Value * exchangeRate);
            }

            public static implicit operator CurrencyRUB(CurrencyUSD usd)
            {
                double exchangeRate = 100;
                return new CurrencyRUB(usd.Value * exchangeRate);
            }
        }

        class CurrencyEUR : Currency
        {
            public CurrencyEUR(double value) : base(value) { }

            public static implicit operator CurrencyUSD(CurrencyEUR eur)
            {
                double exchangeRate = 1.01; 
                return new CurrencyUSD(eur.Value * exchangeRate);
            }

            public static implicit operator CurrencyRUB(CurrencyEUR eur)
            {
                double exchangeRate = 110; 
                return new CurrencyRUB(eur.Value * exchangeRate);
            }
        }

        class CurrencyRUB : Currency
        {
            public CurrencyRUB(double value) : base(value) { }

            public static implicit operator CurrencyUSD(CurrencyRUB rub)
            {
                double exchangeRate = 0.01; 
                return new CurrencyUSD(rub.Value * exchangeRate);
            }

            public static implicit operator CurrencyEUR(CurrencyRUB rub)
            {
                double exchangeRate = 0.009;
                return new CurrencyEUR(rub.Value * exchangeRate);
            }
        }
    }
}