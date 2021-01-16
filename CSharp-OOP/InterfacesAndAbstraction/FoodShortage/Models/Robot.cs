using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }
        public string Model { get; set; }
        public string ID { get; private set; }
    }
}
