namespace TextParser.Core
{
    public interface IToken
    {
		string Value { get; set; }
		int Length { get; }
	}
}
