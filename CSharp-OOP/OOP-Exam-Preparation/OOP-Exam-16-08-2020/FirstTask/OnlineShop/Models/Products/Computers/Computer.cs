using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        // TODO: Change to List

        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList().AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList().AsReadOnly();

        public override double OverallPerformance
            => components.Count == 0
            ? base.OverallPerformance
            : base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);

        public override decimal Price
            => base.Price + Components.Sum(x => x.Price) + Peripherals.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if (Components.Contains(component))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType) // TODO: CHECK THIS!!!!!
        {
            //var validComponent = Components.Any(x => x.GetType().Name == componentType);

            if (!this.Components.Any() || !(this.Components.Any(x => x.GetType().Name == componentType))) // THERE IS "!"
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            var componentToRemove = Components.FirstOrDefault(x => x.GetType().Name == componentType);

            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Contains(peripheral))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any() || !(this.Peripherals.Any(x => x.GetType().Name == peripheralType))) // THERE IS "!"
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            var peripheralToRemove = Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine(
                $" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
