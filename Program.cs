using System.Reflection;
using GetVariableByAttribute;
public class GetVariableByAttributeMain
{
    public static void Main(string[] args)
    {
        var standardClass = new ClassWithAttribute(1,2,3,4,5);
        var inheriter = new ClassThatInherits(11, 12);
        var implementer = new ClassThatImplements(21,22);
        var inheritorImplementor = new ClassThatInheritsAndImplements(41, 42, 43, 44);
        var inheritorFromImplementor = new ClassThatInheritsClassThatImplements(51,52,53);
        var reader = new ClassThatReadsAttribute();
        standardClass.PresentYourself(reader);
        inheriter.PresentYourself(reader);
        implementer.PresentYourself(reader);
        inheritorImplementor.PresentYourself(reader);
        inheritorFromImplementor.PresentYourself(reader);
    }
}

public class ClassThatReadsAttribute
{
    public void Print<T>(T classWithAttribute, Type classWithAttributeType, string indentation)
    {
        var attributeType = typeof(VariableAttribute);
        var members = GetAllMembersWithAttribute(attributeType, classWithAttributeType);

        foreach (var member in members) 
        {
            var val = member.GetValue(classWithAttribute);
            Console.WriteLine(indentation + member.Name + ": " + ((int) val));
        }

    }

    private IEnumerable<MemberInfo> GetAllMembersWithAttribute(Type attributeType, Type classWithAttributeType)
    {
        /*
         * This filter ensures that we only take each property from interfaces once
         * Example:
         *      If my class inherits from a class that implements an interface 
         *      Then both my class and the parent shows that they have the interface
         *      Therefore the interface variable is selected twice
         * This filter prevents that
         */

        var typeFilter = new TypeFilter(InterfaceNotInherited);

        var members = GetMembersWithAttribute(attributeType, classWithAttributeType);
        foreach (Type interfaceType in classWithAttributeType.FindInterfaces(typeFilter, classWithAttributeType.BaseType))
        {
            members = members.Concat(GetMembersWithAttribute(attributeType, interfaceType));
        }
        return members;
    }

    public static bool InterfaceNotInherited(Type typeObj, Object criteriaObj)
    {
        var baseType = (Type)criteriaObj;
        return !baseType.GetInterfaces().Contains(typeObj);
    }

    private IEnumerable<MemberInfo> GetMembersWithAttribute(Type attributeType, Type classWithAttributeType)
    {
        return classWithAttributeType.GetMembers(BindingFlags.Public
                                                 | BindingFlags.NonPublic
                                                 | BindingFlags.Instance
                                                 | BindingFlags.DeclaredOnly)
                                     .Where(field => field.GetCustomAttributes(attributeType, true)
                                     .FirstOrDefault() != null);
    }
}

public static class MemberInfoExtensions
{
    public static object GetValue(this MemberInfo memberInfo, object forObject)
    {
        switch (memberInfo.MemberType)
        {
            case MemberTypes.Field:
                return ((FieldInfo)memberInfo).GetValue(forObject);
            case MemberTypes.Property:
                return ((PropertyInfo)memberInfo).GetValue(forObject);
            default:
                throw new NotImplementedException();
        }
    }
}