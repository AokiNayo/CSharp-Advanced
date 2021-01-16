using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] namesToInvestigate)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfos = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in fieldInfos.Where(x => namesToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var classField in classFields)
            {
                sb.AppendLine($"{classField.Name} must be private!");
            }

            foreach (var classNonPublicMethod in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{classNonPublicMethod.Name} have to be public!");
            }

            foreach (var classPublicMethod in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{classPublicMethod.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
