using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count => Multiprocessor.Count;

        public CPU GetCPU(string brand)
        {
            if (Multiprocessor.Exists(x => x.Brand == brand))
            {
                CPU cpu = Multiprocessor.Find
                    (x => x.Brand == brand);

                return cpu;
            }

            return null;
        }

        public void Add(CPU cpu)
        {
            if (Capacity > Multiprocessor.Count)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            if (Multiprocessor.Exists(x=>x.Brand == brand))
            {
                CPU cpu = Multiprocessor.Find
                    (x => x.Brand == brand);

                Multiprocessor.Remove(cpu);

                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            var mostPowerfulCPU = Multiprocessor.OrderByDescending
                (x => x.Frequency).FirstOrDefault();

            return mostPowerfulCPU;
        }

        

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                stringBuilder.AppendLine(cpu.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
