﻿namespace Nestor.Contracts
{
	public interface IDbSettings
	{
		string ConnectionString { get; set; }

        string Schema { get; set; }

        bool LowerFirstLetter { get; set; }
	}
}
