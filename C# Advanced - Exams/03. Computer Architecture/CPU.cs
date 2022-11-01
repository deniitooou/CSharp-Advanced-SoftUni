using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Brand} CPU:");
            stringBuilder.AppendLine($"Cores: {Cores}");
            stringBuilder.AppendLine($"Frequency: {Frequency:f1} GHz");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
