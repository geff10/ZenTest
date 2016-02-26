using System;

public class TableItem
{
	public string Heading { get; set; }
	public string SubHeading { get; set; }

	public TableItem(string heading, string subheading)
	{
		this.Heading = heading;
		this.SubHeading = subheading;
	}
}