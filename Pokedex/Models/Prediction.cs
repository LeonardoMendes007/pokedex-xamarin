using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
    public class Payload
    {
        public List<Prediction> predictions { get; set; }
    }

    public class Prediction
    {
        public double Probability { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
    }
}
