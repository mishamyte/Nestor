namespace Nestor.Model
{
	public class Nest
	{
		public int Id { get; set; }
		public double Lat { get; set; }
		public double Lng { get; set; }
		public virtual Pokemon Pokemon { get; set; }
	}
}
