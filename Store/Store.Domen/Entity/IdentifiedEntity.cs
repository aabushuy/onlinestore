namespace Store.Domen.Entity
{
	public abstract class IdentifiedEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
