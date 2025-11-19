namespace Marketum.Domain
{  /// <summary>
	/// Representa um funcionário no sistema.
	/// </summary>
	public class Employee : Person
	{
		public string RoleTitle { get; set; } = string.Empty;	

        public override string GetContactSummary()
		{
			return $"Funcionário: {Name}, Cargo: {RoleTitle}";
		}
	}
}