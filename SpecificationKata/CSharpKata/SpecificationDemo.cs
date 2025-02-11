namespace CSharpKata;

static class SpecificationDemo
{
    delegate bool PasswordPolicy(string input);

    static PasswordPolicy All(this PasswordPolicy[] policies) => policies switch
    {
        [] => NoConstraint,
        [var single] => single,
        [var head, .. var tail] => head.And(tail.All())
    };
    

    static PasswordPolicy And(this PasswordPolicy left, PasswordPolicy right) 
        => input => left(input) && right(input);
    
    static PasswordPolicy NoConstraint => input => true;
    
    static PasswordPolicy AtLeast(int length) => input => input.Length >= length;
    static PasswordPolicy ContainsUpperLetter(string input) => input => input.Any(char.IsUpper);
    static PasswordPolicy ContainsLowerLetter(string input) => input => input.Any(char.IsLower);
    static PasswordPolicy ContainsDigit(string input) => input => input.Any(char.IsDigit);
    static PasswordPolicy ContainsAny(char[] chars) => input => input.Any(chars.Contains);
}