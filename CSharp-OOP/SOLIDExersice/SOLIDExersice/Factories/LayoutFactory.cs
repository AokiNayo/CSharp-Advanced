using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using Logger.Common;
using Logger.Models.Contracts;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {
            
        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.Equals(layoutTypeStr,
                    StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstants.InvalidLayoutType);
            }

            object[] ctorArgs = new object[]{};
            ILayout layout =
                (ILayout)Activator.CreateInstance(layoutType, ctorArgs);

            return layout;
        }
    }
}
