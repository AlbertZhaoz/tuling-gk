<Query Kind="Program" />

void Main()
{
	var style = FontStyle.Bold|FontStyle.Italic;
	
	switch (style)
	{
		case FontStyle.Bold:
			"Bold".Dump();
			break;
		case FontStyle.Italic:
			"Italic".Dump();
			break;
		case FontStyle.Bold | FontStyle.Italic:
			"Bold And Italic".Dump();
			break;
		case FontStyle.UnderLine:
			"UnderLine".Dump();
			break;
		default:
			break;
	}
}

[Flags]
enum FontStyle
{
	Bold =1,
	Italic = 2,
	UnderLine = 4
}