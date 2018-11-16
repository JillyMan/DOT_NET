namespace TextParser.Core.Parser
{
	public interface IParser<Input, Output>
	{
		Output Parse (Input path);
	}
}
