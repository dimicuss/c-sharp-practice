namespace OOPLabrab32
{
	interface INameAndCopy
	{
		string Name { get; set; }
		object DeepCopy();
	}
}
	