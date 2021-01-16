using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            Enum.TryParse(computerType, out ComputerType type);

            IComputer computer = type switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, id);

        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            Enum.TryParse(peripheralType, out PeripheralType type);
            IPeripheral peripheral = type switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IComputer currentComputer = computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            currentComputer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, currentComputer.Id);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral currentPeripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (currentPeripheral == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            currentComputer.RemovePeripheral(peripheralType);
            peripherals.Remove(currentPeripheral);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, currentPeripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            Enum.TryParse(componentType, out ComponentType type);

            IComponent component = type switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation),
                ComponentType.Motherboard => new Motherboard(id,manufacturer,model,price,overallPerformance,generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            // THROW EXCEPTION IF COMPUTER NOT FOUND!
            IComputer currentComputer = computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            currentComputer.AddComponent(component);
            components.Add(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComponent currentComponent = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (currentComponent == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            currentComputer.RemoveComponent(componentType);
            components.Remove(currentComponent);

            return String.Format(SuccessMessages.RemovedComponent, componentType, currentComponent.Id);
        }

        public string BuyComputer(int id)
        {
            IComputer currentComputer = computers.FirstOrDefault(x => x.Id == id);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            this.computers.Remove(currentComputer);

            return currentComputer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            if (!this.computers.Any() || !this.computers.Any(c => c.Price <= budget))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            IComputer currentComputer = this.computers.OrderByDescending(c => c.OverallPerformance).FirstOrDefault(c => c.Price <= budget);

            this.computers.Remove(currentComputer);

            return currentComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer currentComputer = computers.FirstOrDefault(x => x.Id == id);

            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return currentComputer.ToString();
        }
    }
}
