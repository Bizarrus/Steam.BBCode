# Steam.BBCode
BBCode-Parser for Steam-API

## Usage

Import neccessary packages:
```
using Steam.BBCode;
using Steam.BBCode.Components;
```

Start parsing your BBCode from Steam/Workshop:
```
BBCode code = new BBCode();
List<Component> components = code.Parse("<BBCODE>"); // Insert your BBCode here!
```

After that, you can iterate over all `Components`:
```

foreach(Component component in components) {
	
	// Bold
	if(component.GetType() == typeof(Bold)) {
		Console.WriteLine("BOLD: " + component.GetContent());
		
	// Code
	} else if(component.GetType() == typeof(Code)) {
		Console.WriteLine("CODE: " + component.GetContent());
	
	// Italic
	} else if(component.GetType() == typeof(Italic)) {
		Console.WriteLine("ITALIC: " + component.GetContent());
		
	// List
	} else if component.GetType() == typeof(List)) {
		List list = (List) component;
		Console.WriteLine("LIST:");

		// Entries
		foreach(string item in list.GetItems()) {
			Console.WriteLine(" >> " + item);
		}

	// NoParse
	} else if(component.GetType() == typeof(NoParse)) {
		Console.WriteLine("NOPARSE: " + component.GetContent());
		
	// PlainText
	} else if(component.GetType() == typeof(PlainText)) {
		Console.WriteLine("PLAINTEXT: " + component.GetContent());
		
	// Quote
	} else if(component.GetType() == typeof(Quote)) {
		Console.WriteLine("QUOTE: " + component.GetContent());

	// Spoiler
	} else if(component.GetType() == typeof(Spoiler)) {
		Console.WriteLine("SPOILER: " + component.GetContent());
		
	// Strike
	} else if(component.GetType() == typeof(Strike)) {
		Console.WriteLine("STRIKE: " + component.GetContent());
		
	// Title
	} else if(component.GetType() == typeof(Title)) {
		Console.WriteLine("TITLE: " + component.GetContent());
		
	// Underline
	} else if(component.GetType() == typeof(Underline)) {
		Console.WriteLine("UNSERLINE: " + component.GetContent());
		
	// URL
	} else if(component.GetType() == typeof(URL)) {
		URL url = (URL) component;
		Console.WriteLine("URL: " + url.GetURL() + " (" + url.GetContent() + ")");

	// Image
	} else if(component.GetType() == typeof(Image)) {
		Image url = (Image) component;
		Console.WriteLine("Image: " + url.GetURL());
	}
}
```

## Is it an BBCode-to-HTML Parser?
NO! This parser is only an parser. If you want a renderer, you must write your own. This library was made to use own renderers.
